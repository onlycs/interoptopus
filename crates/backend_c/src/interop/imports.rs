use std::collections::HashSet;

use crate::Interop;
use interoptopus::backend::IndentWriter;
use interoptopus::lang::Type;
use interoptopus::{Error, indented};

pub fn write_imports(i: &Interop, w: &mut IndentWriter) -> Result<(), Error> {
    indented!(w, r"#include <stdint.h>")?;
    indented!(w, r"#include <stdbool.h>")?;
    indented!(w, r"#include <sys/types.h>")?;

    // Write any user supplied includes into the file.
    for include in &i.additional_includes {
        indented!(w, "#include {}", include)?;
    }

    let mut include_namespaces = HashSet::new();

    for ty in i.inventory.ctypes() {
        let Some(ns) = ty.namespace() else {
            continue;
        };

        if ns != i.namespace {
            continue;
        }

        let Type::Composite(x) = ty else {
            continue;
        };

        x.fields()
            .iter()
            .filter_map(|f| f.the_type().namespace())
            .filter(|import_ns| *import_ns != ns)
            .for_each(|import_ns| {
                include_namespaces.insert(import_ns.to_string());
            });
    }

    for ns_id in include_namespaces {
        let namespace = i.path_for_namespace(&ns_id);
        indented!(w, r"#include <{}>", namespace.to_string_lossy().to_string())?;
    }

    w.newline()?;

    Ok(())
}
