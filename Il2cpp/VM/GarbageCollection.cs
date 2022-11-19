using il2cpplib;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using static il2cpplib.Il2Cpp;

namespace il2cpplib
{
    public class GarbageCollection : Il2cppObjectBase
    {
        public static void Collect(int maxGenerations) => il2cpp_gc_collect(maxGenerations);
        public static void CollectALittle() => il2cpp_gc_collect_a_little();
        public static void Disable() => il2cpp_gc_disable();
        public static void Enable() => il2cpp_gc_enable();
        public static bool Enabled => !il2cpp_gc_is_disabled();
        public static long UsedSize => il2cpp_gc_get_used_size();
        public static long HeapSize => il2cpp_gc_get_heap_size();
        public static IntPtr wbarrier_set_field(IntPtr obj, IntPtr gcObj)
        {
            IntPtr targetAddress;
            il2cpp_gc_wbarrier_set_field(obj, out targetAddress, gcObj);
            return targetAddress;
        }
        public static GCHandle CreateWeakRef(IntPtr obj, bool track_resurrection)
           => new GCHandle() { Handle = il2cpp_gchandle_new_weakref(obj, track_resurrection) };
        public static GCHandle CreateHandle(IntPtr obj, bool pinned)
            => new GCHandle() { Handle = il2cpp_gchandle_new(obj, pinned) };
    }
}
