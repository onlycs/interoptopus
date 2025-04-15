use crate::Interop;
use interoptopus::backend::IndentWriter;
use interoptopus::{Error, indented};

pub fn write_namespaces(i: &Interop, w: &mut IndentWriter, f: impl FnOnce(&mut IndentWriter) -> Result<(), Error>) -> Result<(), Error> {
    if !i.cpp && i.namespace != "" {
        panic!("Namespaces are not supported in C");
    }

    if i.namespace == "" {
        return f(w);
    }

    for ns_segment in i.namespace.split("::") {
        indented!(w, r"namespace {} {{", ns_segment)?;
    }

    f(w)?;

    for ns_segment in i.namespace.split("::").collect::<Vec<_>>().into_iter().rev() {
        indented!(w, r"}} // namespace {ns_segment}")?;
    }

    Ok(())
}
