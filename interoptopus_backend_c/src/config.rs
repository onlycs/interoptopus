/// Configures C code generation.
#[derive(Clone, Debug)]
pub struct Config {
    /// Whether to write conditional directives like `#ifndef _X`.
    pub directives: bool,
    /// Whether to write `#include <>` directives.
    pub imports: bool,
    /// The `_X` in `#ifndef _X` to be used.
    pub ifndef: String,
    /// Multiline string with custom `#define` values.
    pub custom_defines: String,
    /// Prefix to be applied to any function, e.g., `__DLLATTR`.
    pub function_attribute: String,
    /// Comment at the very beginning of the file, e.g., `// (c) My Company.`
    pub file_header_comment: String,
}

impl Default for Config {
    fn default() -> Self {
        Self {
            directives: true,
            imports: true,
            file_header_comment: "// Automatically generated by Interoptopus.".to_string(),
            ifndef: "interoptopus_generated".to_string(),
            custom_defines: "".to_string(),
            function_attribute: "".to_string(),
        }
    }
}
