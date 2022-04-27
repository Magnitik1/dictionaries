using Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entering {
    public class Entering {
        public static ConsoleKeyInfo cki;
        public static string aval="(Is not avaliable)";
        public static int Choose(List<string> arr, int pass = 0, int skip=-1) {
            int num = arr.Count;
            int q = pass;
            bool el = true;
            if (Console.CursorVisible) { el = Console.CursorVisible = false; }
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Black;
            if (q == skip) {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(arr[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 1; i < num; i++) { Console.WriteLine(" " + arr[i]); }
            do {
                gg:

                cki = Console.ReadKey(true);
                if(q==skip)Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(1, q); Console.WriteLine(arr[q - pass]);
                if (q == skip) Console.ForegroundColor = ConsoleColor.White;
                if (cki.Key == ConsoleKey.DownArrow) { q++; if (q >= num + pass) { q = pass;  } }
                if (cki.Key == ConsoleKey.UpArrow) { q--; if (q < pass) { q = num - 1 + pass;  } }
                if (cki.Key == ConsoleKey.R) return -1;
                if (cki.Key == ConsoleKey.Backspace) { Console.Clear(); YourLanguage.prap = false; Program.Main(null); }
                if (cki.Key == ConsoleKey.Escape) { System.Environment.Exit(0); }
                Console.SetCursorPosition(1, q);
                Console.ForegroundColor = ConsoleColor.Black;
                if (q == skip) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(arr[q - pass]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                if (q == skip&&cki.Key==ConsoleKey.Enter) {
                    Console.SetCursorPosition(11, q);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(aval);
                    Console.ForegroundColor = ConsoleColor.White;
                    goto gg;
                }

            } while (cki.Key != ConsoleKey.Enter);
            if (el) Console.CursorVisible = true;
            return q;
        }
        public static int Choose(string[] arr,int pass=0,int skip=-1) {
            List<string> lst = new List<string>() { arr[0] };
            for (int i = 1; i < arr.Length; i++) {
                lst.Add(arr[i]);
            }
            return Choose(lst, pass, skip);
        }
    }
}
