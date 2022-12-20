using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace il2cpplib
{
    public class StringUtils
    {
        public static string ReadSystemString(IntPtr System_String)
        {
            return Marshal.PtrToStringUni(System_String + (IntPtr.Size * 3));
        }

        public static string ReadString(IntPtr String)
        {
            return Marshal.PtrToStringAnsi(String);
        }

        public unsafe static IntPtr StrToSys_Str(string str)
        {
            if(string.IsNullOrEmpty(str))
                return IntPtr.Zero;

            str += "\0";

            fixed(char* strPtr = str)
                return Il2Cpp.il2cpp_string_new_utf16(strPtr, str.Length + 1);
        }

    }
}
