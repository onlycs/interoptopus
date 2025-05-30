use interoptopus::{ffi, ffi_type};

#[ffi_type]
#[derive(Clone)]
pub struct UseSliceAndVec<'a> {
    pub s1: ffi::Slice<'a, ffi::String>,
    pub s2: ffi::Vec<ffi::String>,
}
