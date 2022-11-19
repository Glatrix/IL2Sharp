using il2cpplib;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using static il2cpplib.Il2Cpp;

namespace il2cpplib
{
    // System.Threading.Thread
    public class GCHandle : IDisposable
    {
        public uint Handle { get; set; }
        public void Free() => il2cpp_gchandle_free(Handle);
        public void Dispose() => Free();
        public IntPtr Target => il2cpp_gchandle_get_target(Handle);
    }
}
