using CodeInject.Il2cpp.Utilities;
using il2cpplib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Il2cpp.VM
{
    public unsafe class Il2CppException : Exception
    {
        public override string Message => base.Message;

        public static void HandlePossibleException(IntPtr exception)
        {
            if (exception == IntPtr.Zero)
                return;

            //Thanks to Il2cppUnhollower
            var ourMessageBytes = new byte[65536];
            fixed (byte* message = ourMessageBytes)
                Il2Cpp.il2cpp_format_exception(exception, (void*)message, ourMessageBytes.Length);
            string str = Encoding.UTF8.GetString(ourMessageBytes, 0, Array.IndexOf<byte>(ourMessageBytes, (byte)0));
            fixed (byte* output = ourMessageBytes)
                Il2Cpp.il2cpp_format_stack_trace(exception, (void*)output, ourMessageBytes.Length);
            string err = str + Encoding.UTF8.GetString(ourMessageBytes, 0, Array.IndexOf<byte>(ourMessageBytes, (byte)0));
            Logger.Error(err);
            File.WriteAllText("ERROR.txt", err);
        }
    }
}
