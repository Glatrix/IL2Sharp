using System;

namespace il2cpplib
{
    public enum Il2CppTypes
    {
        Type_END = 0x00,       /* End of List */
        Type_VOID = 0x01,
        Type_BOOLEAN = 0x02,
        Type_CHAR = 0x03,
        Type_I1 = 0x04,
        Type_U1 = 0x05,
        Type_I2 = 0x06,
        Type_U2 = 0x07,
        Type_I4 = 0x08,
        Type_U4 = 0x09,
        Type_I8 = 0x0a,
        Type_U8 = 0x0b,
        Type_R4 = 0x0c,
        Type_R8 = 0x0d,
        Type_STRING = 0x0e,
        Type_PTR = 0x0f,       /* arg: <type> token */
        Type_BYREF = 0x10,       /* arg: <type> token */
        Type_VALUETYPE = 0x11,       /* arg: <type> token */
        Type_CLASS = 0x12,       /* arg: <type> token */
        Type_VAR = 0x13,       /* Generic parameter in a generic type definition, represented as number (compressed unsigned integer) number */
        Type_ARRAY = 0x14,       /* type, rank, boundsCount, bound1, loCount, lo1 */
        Type_GENERICINST = 0x15,     /* <type> <type-arg-count> <type-1> \x{2026} <type-n> */
        Type_TYPEDBYREF = 0x16,
        Type_I = 0x18,
        Type_U = 0x19,
        Type_FNPTR = 0x1b,        /* arg: full method signature */
        Type_OBJECT = 0x1c,
        Type_SZARRAY = 0x1d,       /* 0-based one-dim-array */
        Type_MVAR = 0x1e,       /* Generic parameter in a generic method definition, represented as number (compressed unsigned integer)  */
        Type_CMOD_REQD = 0x1f,       /* arg: typedef or typeref token */
        Type_CMOD_OPT = 0x20,       /* optional arg: typedef or typref token */
        Type_INTERNAL = 0x21,       /* CLR internal type */
        Type_MODIFIER = 0x40,       /* Or with the following types */
        Type_SENTINEL = 0x41,       /* Sentinel for varargs method signature */
        Type_PINNED = 0x45,       /* Local var that points to pinned object */
        Type_ENUM = 0x55,        /* an enumeration */
        Type_IL2CPP_TYPE_INDEX = 0xff        /* an index into IL2CPP type metadata table */
    }

}

