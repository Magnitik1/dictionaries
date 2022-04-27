using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entering;

namespace Dictionaries {

    class Translate {
        public static string write = "Write ";
        public static string Idon = "I don't know this word";
        public static string writeto = " word to translate to ";
        public static string quest = "Export to another file?";
        public static void translating() {
            Console.Clear();
            Console.WriteLine(write + Program.langs[0] + writeto + Program.langs[1]);
            string s = Console.ReadLine();
            List<string> all = new List<string>();
            List<string> words = new List<string>();
            StreamReader sr = new StreamReader(Program.way);
            while (true) {
                bool p = true;
                string e = sr.ReadLine();
                if (e == null) break;
                if (e.Contains(s)) {
                    string d;
                    string a1 = add1(e, s);
                    string a2 = add2(e, s);
                    if (s == a1) { if (Program.variant == 2) { words.Add(a2); all.Add(a1 + " - " + a2); } }
                    else if (s == a2) { if (Program.variant == 1) { words.Add(a1); all.Add(a2 + " - " + a1); } }
                }
            }
            sr.Close();
            if (words.Count < 1) {
                Console.Clear();
                Console.WriteLine(Idon);
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            Console.WriteLine();
            foreach (var w in words) { Console.WriteLine(w); }
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine(quest);
            string[] g = { "Yes", "No" };
            int y = Entering.Choose(g, 1);

            if (y == 1) { export(all); }
            Console.Clear();
        }

        private static void export(List<string> words) {
            if (!File.Exists("..\\..\\..\\Words.txt")) { File.Create("..\\..\\..\\Words.txt").Close(); }
            StreamWriter sw = new StreamWriter("..\\..\\..\\Words.txt", true);
            foreach (var el in words) {
                sw.WriteLine("(" + Program.langs[0] + " to " + Program.langs[1] + ") " + el);
            }
            sw.Close();
        }

        private static string add1(string e, string s) {
            return e.Substring(e.LastIndexOf('-') + 2, e.Length - e.LastIndexOf('-') - 2);
        }

        private static string add2(string e, string s) {
            return e.Substring(0, e.LastIndexOf('-') - 1);
        }
    }
}
