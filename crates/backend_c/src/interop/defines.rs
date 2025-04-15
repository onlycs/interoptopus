use crate::Interop;
use interoptopus::backend::IndentWriter;
use interoptopus::{Error, indented};

pub fn write_custom_defines(i: &Interop, w: &mut IndentWriter) -> Result<(), Error> {
    indented!(w, "{}", i.custom_defines)
}

pub fn write_ifndef(i: &Interop, w: &mut IndentWriter, f: impl FnOnce(&mut IndentWriter) -> Result<(), Error>) -> Result<(), Error> {
    if i.directives {
        indented!(w, r"#ifndef {}_{}", i.ifndef, i.namespace.split("::").collect::<Vec<_>>().join("_"))?;
        indented!(w, r"#define {}_{}", i.ifndef, i.namespace.split("::").collect::<Vec<_>>().join("_"))?;
        w.newline()?;
    }

    f(w)?;

    if i.directives {
        w.newline()?;
        indented!(w, r"#endif /* {} */", i.ifndef)?;
    }

    Ok(())
}

pub fn write_ifdefcpp(i: &Interop, w: &mut IndentWriter, f: impl FnOnce(&mut IndentWriter) -> Result<(), Error>) -> Result<(), Error> {
    if !i.cpp && i.directives {
        indented!(w, r"#ifdef __cplusplus")?;
        indented!(w, r#"extern "C" {{"#)?;
        indented!(w, r"#endif")?;

        w.newline()?;
        f(w)?;
        w.newline()?;

        indented!(w, r"#ifdef __cplusplus")?;
        indented!(w, r#"}} // extern "C""#)?;
        indented!(w, r"#endif")?;
    } else {
        f(w)?;
    }

    Ok(())
}
