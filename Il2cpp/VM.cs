using il2cpplib;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using static il2cpplib.Il2Cpp;

namespace il2cpplib 
{
    public class VMThread : CppObject
    {
        private VMThread(IntPtr thread) { this.Address = thread; }
        public VMThread(Action action) { Create(action); }
        public static VMThread Current => new VMThread(il2cpp_thread_current());
        public static void Attatch() { il2cpp_thread_attach(il2cpp_domain_get()); }
        public static void Detach() { il2cpp_thread_detach(il2cpp_domain_get()); }
        private void Create(Action action, bool loop = true)
        {
            var thread = new Thread(() =>
            {
                this.Address = il2cpp_thread_attach(il2cpp_domain_get());
                while (loop) { action(); }
            });
            thread.Start();
        }

        public static bool InVmThread => Current.IsVMThread;
        public bool IsVMThread => il2cpp_is_vm_thread(Address);
        public static void WalkFrameStack(IntPtr func, IntPtr user_data)
            => il2cpp_current_thread_walk_frame_stack(func, user_data);
        public static void GetFrameAt(int offset, IntPtr frame)
            => il2cpp_current_thread_get_frame_at(offset, frame);
        public static void GetTopFrame(IntPtr frame)
            => il2cpp_current_thread_get_top_frame(frame);
        public static int GetStackDepth()
            => il2cpp_current_thread_get_stack_depth();
        public void Intercept_WalkFrameStack(IntPtr func, IntPtr user_data)
            => il2cpp_thread_walk_frame_stack(Address, func, user_data);
        public void Intercept_GetFrameAt(int offset, IntPtr frame)
            => il2cpp_thread_get_frame_at(Address, offset, frame);
        public void Intercept_GetTopFrame(IntPtr frame)
            => il2cpp_thread_get_top_frame(Address, frame);
        public int Intercept_GetStackDepth()
            => il2cpp_thread_get_stack_depth(Address);

        public unsafe List<VMThread> AttatchedThreads
        {
            get
            {
                List<VMThread> temp = new List<VMThread>();
                uint Iter = 0u;
                IntPtr Thread;
                while ((Thread = (IntPtr)il2cpp_thread_get_all_attached_threads(ref Iter)) != IntPtr.Zero)
                {
                    temp.Add(new VMThread(Thread));
                }
                return temp;
            }
        }
    }

    public class VMGC : CppObject
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
        public static VmGcHandle CreateWeakRef(IntPtr obj, bool track_resurrection)
           => new VmGcHandle() { Handle = il2cpp_gchandle_new_weakref(obj, track_resurrection) };
        public static VmGcHandle CreateHandle(IntPtr obj, bool pinned)
            => new VmGcHandle() { Handle = il2cpp_gchandle_new(obj, pinned) };
    }

    // System.Threading.Thread
    public class VmGcHandle : IDisposable
    {
        public uint Handle { get; set; }
        public void Free() => il2cpp_gchandle_free(Handle);
        public void Dispose() => Free();
        public IntPtr Target => il2cpp_gchandle_get_target(Handle);
    }
}




