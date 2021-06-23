// Automatically generated by Interoptopus.

#ifndef interoptopus_generated
#define interoptopus_generated

#ifdef __cplusplus
extern "C" {
#endif

#include <stdint.h>
#include <stdbool.h>



#define C1 1
#define C2 1
#define C3 -100

typedef enum EnumDocumented
    {
    A = 0,
    B = 1,
    } EnumDocumented;

typedef struct Context Context;

typedef struct Opaque Opaque;

typedef struct SimpleClass SimpleClass;

typedef struct Empty Empty;

typedef enum FFIError
    {
    Ok = 0,
    Null = 100,
    Fail = 200,
    } FFIError;

typedef struct Phantomu8
    {
    uint32_t x;
    } Phantomu8;

typedef struct SomeForeignType
    {
    uint32_t x;
    } SomeForeignType;

typedef struct StructDocumented
    {
    float x;
    } StructDocumented;

typedef struct Tupled
    {
    uint8_t x0;
    } Tupled;

typedef struct UseAsciiStringPattern
    {
    uint8_t* ascii_string;
    } UseAsciiStringPattern;

typedef struct Vec
    {
    double x;
    double z;
    } Vec;

typedef struct Vec1
    {
    float x;
    float y;
    } Vec1;

typedef struct Vec2
    {
    double x;
    double z;
    } Vec2;

typedef struct Vec3f32
    {
    float x;
    float y;
    float z;
    } Vec3f32;

typedef uint8_t (*fptr_fn_u8_rval_u8)(uint8_t x0);

typedef struct FFISliceu32
    {
    uint32_t* data;
    uint64_t len;
    } FFISliceu32;

typedef struct FFISliceu8
    {
    uint8_t* data;
    uint64_t len;
    } FFISliceu8;

typedef struct Genericu32
    {
    uint32_t* x;
    } Genericu32;

typedef struct Genericu8
    {
    uint8_t* x;
    } Genericu8;

typedef uint8_t (*fptr_fn_FFISliceu8_rval_u8)(FFISliceu8 x0);


void primitive_void();
void primitive_void2();
bool primitive_bool(bool x);
uint8_t primitive_u8(uint8_t x);
uint16_t primitive_u16(uint16_t x);
uint32_t primitive_u32(uint32_t x);
uint64_t primitive_u64(uint64_t x);
int8_t primitive_i8(int8_t x);
int16_t primitive_i16(int16_t x);
int32_t primitive_i32(int32_t x);
int64_t primitive_i64(int64_t x);
int64_t* ptr(int64_t* x);
int64_t* ptr_mut(int64_t* x);
int64_t** ptr_ptr(int64_t** x);
int64_t* ptr_simple(int64_t* x);
int64_t* ptr_simple_mut(int64_t* x);
bool ptr_option(int64_t* x);
bool ptr_option_mut(int64_t* x);
Tupled tupled(Tupled x);
FFIError complex_1(Vec3f32 _a, Empty* _b);
Opaque* complex_2(SomeForeignType _cmplx);
uint8_t callback(fptr_fn_u8_rval_u8 callback, uint8_t value);
uint32_t generic_1(Genericu32 x, Phantomu8 _y);
uint8_t generic_2(Genericu8 x, Phantomu8 _y);
EnumDocumented documented(StructDocumented _x);
uint32_t pattern_ascii_pointer(uint8_t* x, UseAsciiStringPattern y);
uint32_t pattern_ffi_slice(FFISliceu32 ffi_slice);
uint8_t pattern_ffi_slice_delegate(fptr_fn_FFISliceu8_rval_u8 callback);
Vec1 ambiguous_1(Vec1 x);
Vec2 ambiguous_2(Vec2 x);
bool ambiguous_3(Vec1 x, Vec2 y);
Vec namespaced_type(Vec x);
FFIError pattern_class_create(Context** context_ptr, uint32_t value);
FFIError pattern_class_destroy(Context** context_ptr);
uint32_t pattern_class_method(Context* context);
FFIError pattern_class_method_success_enum_ok(Context* _context);
FFIError pattern_class_method_success_enum_fail(Context* _context);
FFIError simple_class_create(SimpleClass** context_ptr, uint32_t x);
FFIError simple_class_destroy(SimpleClass** context_ptr);
FFIError simple_class_result(SimpleClass* context_ptr, uint32_t x);
uint32_t simple_class_value(SimpleClass* context_ptr, uint32_t x);
uint32_t simple_class_mut_self(SimpleClass* context_ptr, uint32_t x);
void simple_class_void(SimpleClass* context_ptr);
uint32_t simple_class_extra_method(SimpleClass* _context);

#ifdef __cplusplus
}
#endif

#endif /* interoptopus_generated */
