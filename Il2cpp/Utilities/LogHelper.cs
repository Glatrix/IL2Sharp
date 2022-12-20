using il2cpplib;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Forms;
using static System.Console;

namespace CodeInject.Il2cpp.Utilities
{
    public static class Logger
    {
        private static List<string> Messages = new List<string>();
        private static List<string> Warnings = new List<string>();
        private static List<string> Exceptns = new List<string>();

        public static void Log(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Messages.Add(msg);
        }
        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Warnings.Add(msg);
        }
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Exceptns.Add(msg);
        }  
    }
}
