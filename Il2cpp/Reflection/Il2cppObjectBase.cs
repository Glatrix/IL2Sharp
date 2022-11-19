using System;
using System.Runtime.InteropServices;

namespace il2cpplib
{
    public delegate Il2cppObjectBase GetObject();
    /// <summary> ~ The Base for all Il2cpp Api Objects. (Not UnityEngine Objects)</summary>
    public unsafe class Il2cppObjectBase
    {
        public IntPtr Address { get; set; }

        public IntPtr CachePtr { 
            get
            {
                //(x64 - 0x10) (x86 - 0x8) m_CachePtr
                return *(IntPtr*)(Address + (IntPtr.Size * 2));
            } 
        }



        public static implicit operator Il2cppObjectBase(IntPtr l) { return new Il2cppObjectBase { Address = l }; }
        public static implicit operator IntPtr(Il2cppObjectBase l) { return l.Address; }
    }
}

