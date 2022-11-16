using System;
using System.Runtime.InteropServices;

namespace il2cpplib
{
    /// <summary> ~ Il2cpp Object (For Simplicity)</summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe class CppObject
    {
        /// <summary>
        /// The address of the current object.
        /// </summary>
        [FieldOffset(0x8)]
        public IntPtr Address = IntPtr.Zero; //Cannot be Property because of unsafe casting.
    }
}

