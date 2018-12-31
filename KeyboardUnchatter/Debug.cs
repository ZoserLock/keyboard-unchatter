using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardUnchatter
{
    internal class Debug
    {
        [Conditional("DEBUG")]
        public static void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
