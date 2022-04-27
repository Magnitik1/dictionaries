using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries {
    class Settings {
        public static void SetStart() {
            Console.CursorVisible = false;
            Console.WindowWidth = 78;
            Console.WindowHeight = 20;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }
    }
}
