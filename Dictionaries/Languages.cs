using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries {
    class Languages {
        public static int x = 14, y = 4;
        public static bool prap;
        public static int left = 0, right = 1, col = 0;
        public static ConsoleKeyInfo cki;
        public static List<string> languages = new List<string>() 
        { "Українська", "English", "Polskie", "Русский", "Deutsch", "Español", "Français" };
        public static string[] ChoosingLanguage() {
            prap = true;
            string[] s = new string[2];
            while (prap) {
                drawing();
                control();
            }
            int count = languages.Count;
            int l1 = left;
            int r1 = right;
            left += 2;
            if (left >= count) left -= count;
            right += 2;
            if (right >= count) right -= count;
            s[0] = languages[left];
            s[1] = languages[right];
            right = r1;
            left = l1;
            Console.ForegroundColor = ConsoleColor.White;
            return s;
        }

        private static void control() {
            int count = languages.Count;
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.DownArrow) {
                if (col == 0) { left++; if (left >= count) { left = 0; } if (left == right) left++; }
                else { right++; if (right >= count) { right = 0; } if (left == right) right++;
                    if (right >= count) { right = 0; } }
            }
            if (cki.Key == ConsoleKey.UpArrow) {
                if (col == 0) { left--; if (left == right) left--;if (left < 0) { left = count - 1; }  }
                else { right--; if (left == right) right--;if (right < 0) { right = count - 1; }  
                    if (right < 0) { right = count - 1; } }
            }
            if (cki.Key == ConsoleKey.LeftArrow) { col = 0; }
            if (cki.Key == ConsoleKey.RightArrow) { col = 1; }
            if (cki.Key == ConsoleKey.Enter || cki.Key == ConsoleKey.Spacebar) { prap = false; }
        }

        static void drawing() {
            int count = languages.Count;
            Console.Clear();
            for (int i = 0; i < 5; i++) {
                int a1 = left + i;
                int b1 = right + i;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (i == 2) {
                    Console.SetCursorPosition(x + 4, y*2);
                    Console.Write("→   →   →   →  to  →   →   →   →");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (i == 2 && col == 0) {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                if (a1 >= count) a1 -= count;
                if (b1 >= count) b1 -= count;
                Console.SetCursorPosition(x, y + (i * 2));
                Console.Write(languages[a1]);
                if (i == 2) {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (i == 2 && col == 1) {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.SetCursorPosition(x * 3+5, y + (i * 2));
                Console.Write(languages[b1]);

                Console.BackgroundColor = ConsoleColor.Black;

            }
        }
    }
}
