using il2cpplib;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using static il2cpplib.Il2Cpp;

namespace il2cpplib 
{
    public class VMThread : Il2cppObjectBase
    {
        public static void RuntimeInvoker(Action action) => new VMThread(action, false);


        private VMThread(IntPtr thread) { this.Address = thread; }
        public VMThread(Action action) { Create(action); }
        public VMThread(Action action, bool loop) { Create(action, loop); }

        private bool _Quit = false;

        /// ONLY works on threads created with VMThread</summary>
        public void Quit()
        {
            _Quit = true;
        }

        public static VMThread Current => new VMThread(il2cpp_thread_current());
        public static void Attatch() { il2cpp_thread_attach(il2cpp_domain_get()); }
        public static void Detach() { il2cpp_thread_detach(il2cpp_domain_get()); }



        private void Create(Action action, bool loop = true)
        {
            var thread = new Thread(() =>
            {
                this.Address = il2cpp_thread_attach(il2cpp_domain_get());
                if (!loop)
                {
                    try { action(); }
                    catch { }
                    Thread.CurrentThread.Abort();
                }
                else
                {
                    while (loop) 
                    {
                        try { action(); }
                        catch { }
                        if (_Quit){ break; }
                    }
                    Thread.CurrentThread.Abort();
                }
            });
            thread.IsBackground = true;
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

        public static unsafe List<VMThread> AttatchedThreads
        {
            get
            {
                List<VMThread> temp = new List<VMThread>();
                uint Iter = 0u;
                IntPtr Thread;

                IntPtr* threads = (IntPtr*)il2cpp_thread_get_all_attached_threads(ref Iter);

                for(int i = 0; i < Iter; i++)
                {
                    temp.Add(new VMThread(threads[i]));
                }

                return temp;
            }
        }
    }

}




