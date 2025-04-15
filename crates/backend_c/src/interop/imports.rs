use crate::Interop;
use interoptopus::backend::IndentWriter;
use interoptopus::{Error, indented};

pub fn write_imports(i: &Interop, w: &mut IndentWriter) -> Result<(), Error> {
    indented!(w, r"#include <stdint.h>")?;
    indented!(w, r"#include <stdbool.h>")?;
    indented!(w, r"#include <sys/types.h>")?;

    // Write any user supplied includes into the file.
    for include in &i.additional_includes {
        indented!(w, "#include {}", include)?;
    }

    for ns_id in i.inventory.namespaces() {
        let namespace = i.path_for_namespace(&ns_id);
        indented!(w, r"#include <{}>", namespace.to_string_lossy().to_string())?;
    }

    w.newline()?;

    Ok(())
}
