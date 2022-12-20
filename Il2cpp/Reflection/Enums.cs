using System;

namespace il2cpplib
{
    [Flags]
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

    [Flags]
    public enum TypeAttributes : uint
    {
        // Visibility attributes
        VisibilityMask = 0x00000007,    // Use this mask to retrieve visibility information
        NotPublic = 0x00000000, // Class has no public scope
        Public = 0x00000001,    // Class has public scope
        NestedPublic = 0x00000002,  // Class is nested with public visibility
        NestedPrivate = 0x00000003, // Class is nested with private visibility
        NestedFamily = 0x00000004,  // Class is nested with family visibility
        NestedAssembly = 0x00000005,    // Class is nested with assembly visibility
        NestedFamANDAssem = 0x00000006, // Class is nested with family and assembly visibility
        NestedFamORAssem = 0x00000007,  // Class is nested with family or assembly visibility

        // Class layout attributes
        LayoutMask = 0x00000018,    // Use this mask to retrieve class layout information
        AutoLayout = 0x00000000,    // Class fields are auto-laid out
        SequentialLayout = 0x00000008,  // Class fields are laid out sequentially
        ExplicitLayout = 0x00000010,    // Layout is supplied explicitly

        // Class semantics attributes
        ClassSemanticMask = 0x00000020, // Use this mask to retrieve class semantics information
        Class = 0x00000000, // Type is a class
        Interface = 0x00000020, // Type is an interface

        // Special semantics in addition to class semantics
        Abstract = 0x00000080,  // Class is abstract
        Sealed = 0x00000100,    // Class cannot be extended
        SpecialName = 0x00000400,   // Class name is special

        // Implementation attributes
        Import = 0x00001000,    // Class/Interface is imported
        Serializable = 0x00002000,  // Class is serializable
        WindowsRuntime = 0x00004000,    // Windows Runtime type

        // String formatting attributes
        StringFormatMask = 0x00030000,  // Use this mask to retrieve string information for native interop
        AnsiClass = 0x00000000, // LPSTR is interpreted as ANSI
        UnicodeClass = 0x00010000,  // LPSTR is interpreted as Unicode
        AutoClass = 0x00020000, // LPSTR is interpreted automatically

        // Class initialization attributes
        BeforeFieldInit = 0x00100000,   // Initialize the class before first static field access

        // Additional flags
        RTSpecialName = 0x00000800, // CLI provides 'special' behavior, depending upon the name of the Type
        HasSecurity = 0x00040000,   // Type has security associate with it
        Forwarder = 0x00200000,   // Exported type is a type forwarder
    }



    [Flags]
    public enum PropertyAttributes : ushort
    {
        None = 0x0000,
        SpecialName = 0x0200,   // Property is special
        RTSpecialName = 0x0400, // Runtime(metadata internal APIs) should check name encoding
        HasDefault = 0x1000,    // Property has default
        Unused = 0xe9ff  // Reserved: shall be zero in a conforming implementation
    }

    [Flags]
    public enum FieldAttributes : ushort
    {
        FieldAccessMask = 0x0007,
        CompilerControlled = 0x0000,    // Member not referenceable
        Private = 0x0001,   // Accessible only by the parent type
        FamANDAssem = 0x0002,   // Accessible by sub-types only in this assembly
        Assembly = 0x0003,  // Accessible by anyone in the Assembly
        Family = 0x0004,    // Accessible only by type and sub-types
        FamORAssem = 0x0005,    // Accessible by sub-types anywhere, plus anyone in the assembly
        Public = 0x0006,    // Accessible by anyone who has visibility to this scope field contract attributes

        Static = 0x0010,    // Defined on type, else per instance
        InitOnly = 0x0020,  // Field may only be initialized, not written after init
        Literal = 0x0040,   // Value is compile time constant
        NotSerialized = 0x0080, // Field does not have to be serialized when type is remoted
        SpecialName = 0x0200,   // Field is special

        // Interop Attributes
        PInvokeImpl = 0x2000,   // Implementation is forwarded through PInvoke

        // Additional flags
        RTSpecialName = 0x0400, // CLI provides 'special' behavior, depending upon the name of the field
        HasFieldMarshal = 0x1000,   // Field has marshalling information
        HasDefault = 0x8000,    // Field has default
        HasFieldRVA = 0x0100     // Field has RVA
    }



    [Flags]
    public enum MethodAttributes : ushort
    {
        MemberAccessMask = 0x0007,
        CompilerControlled = 0x0000,    // Member not referenceable
        Private = 0x0001,   // Accessible only by the parent type
        FamANDAssem = 0x0002,   // Accessible by sub-types only in this Assembly
        Assembly = 0x0003,  // Accessibly by anyone in the Assembly
        Family = 0x0004,    // Accessible only by type and sub-types
        FamORAssem = 0x0005,    // Accessibly by sub-types anywhere, plus anyone in assembly
        Public = 0x0006,    // Accessibly by anyone who has visibility to this scope

        Static = 0x0010,    // Defined on type, else per instance
        Final = 0x0020, // Method may not be overridden
        Virtual = 0x0040,   // Method is virtual
        HideBySig = 0x0080, // Method hides by name+sig, else just by name

        VtableLayoutMask = 0x0100,  // Use this mask to retrieve vtable attributes
        ReuseSlot = 0x0000, // Method reuses existing slot in vtable
        NewSlot = 0x0100,   // Method always gets a new slot in the vtable

        CheckAccessOnOverride = 0x0200,   // Method can only be overriden if also accessible
        Abstract = 0x0400,  // Method does not provide an implementation
        SpecialName = 0x0800,   // Method is special

        // Interop Attributes
        PInvokeImpl = 0x2000,   // Implementation is forwarded through PInvoke
        UnmanagedExport = 0x0008,   // Reserved: shall be zero for conforming implementations

        // Additional flags
        RTSpecialName = 0x1000, // CLI provides 'special' behavior, depending upon the name of the method
        HasSecurity = 0x4000,   // Method has security associate with it
        RequireSecObject = 0x8000    // Method calls another method containing security code
    }


    [Flags]
    public enum MethodImplAttributes : ushort
    {
        CodeTypeMask = 0x0003,
        IL = 0x0000,    // Method impl is CIL
        Native = 0x0001,    // Method impl is native
        OPTIL = 0x0002, // Reserved: shall be zero in conforming implementations
        Runtime = 0x0003,   // Method impl is provided by the runtime

        ManagedMask = 0x0004,   // Flags specifying whether the code is managed or unmanaged
        Unmanaged = 0x0004, // Method impl is unmanaged, otherwise managed
        Managed = 0x0000,   // Method impl is managed

        ForwardRef = 0x0010,    // The method is declared, but its implementation is provided elsewhere.
        PreserveSig = 0x0080,   // The method signature is exported exactly as declared.
        InternalCall = 0x1000,  // The call is internal, that is, it calls a method that's implemented within the CLR.
        Synchronized = 0x0020,  // The method can be executed by only one thread at a time.
                                // Static methods lock on the type, whereas instance methods lock on the instance.
        NoOptimization = 0x0040,    // The method is not optimized by the just-in-time (JIT) compiler or by native codegen.
        NoInlining = 0x0008,    // The method cannot be inlined.
        AggressiveInlining = 0x0100,    // The method should be inlined if possible.
        AggressiveOptimization = 0x0200,    // The method contains code that should always be optimized by the JIT compiler.
    }
}

