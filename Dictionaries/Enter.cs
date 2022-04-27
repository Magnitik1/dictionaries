using entering;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Dictionaries {
    public static class Enter {
        public static bool prap;
        public static string[] s = { "Translate", "Add new word(s)", "Delete word(s)", "Translate with Internet","Take a look on list with all words" ,"Change languages", "Change menu language", "Exit" };

        public static void ChooseWorkToDo() {

            int f = containsmthng() ? 0 : 1;
            int y = Entering.Choose(s, 1, f);
            DoWhatYouChoosed(y);
        }

        private static bool containsmthng() {
            if (File.Exists(Program.way)) {
                StreamReader sr = new StreamReader(Program.way);
                string temp = sr.ReadToEnd();
                sr.Close();
                if (temp == null || temp.Length < 1) return false;
                return true;
            }
            return false;
        }
        public static String TranslateWord(string word, string toLanguage,string fromLanguage) {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={word}";
            var webClient = new WebClient {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try {
                result = result.Substring(4, result.IndexOf("\"", 4) - 4);
                return result;
            }
            catch {
                return "Error";
            }
        }
        private static void DoWhatYouChoosed(int y) {
            if (y == -1) {//R - pressed
                string temp = Program.langs[0];
                Program.langs[0] = Program.langs[1];
                Program.langs[1] = temp;
                bool tempprap = prap;
                Program.FindWay();
                prap = tempprap;
                Program.first = 1;
                return;
            }
            if (y == 4) {
                string auto = "uk";
                string url = "uk";
                if (Program.langs[0] == "English") auto = "en"; 
                if (Program.langs[0] == "Polskie") auto = "pl"; 
                if (Program.langs[0] == "Русский") auto = "ru"; 
                if (Program.langs[0] == "Deutsch") auto = "de"; 
                if (Program.langs[0] == "Español") auto = "es"; 
                if (Program.langs[0] == "Français")auto = "fr";
                if (Program.langs[1] == "English") url = "en"; 
                if (Program.langs[1] == "Polskie") url = "pl"; 
                if (Program.langs[1] == "Русский") url = "ru"; 
                if (Program.langs[1] == "Deutsch") url = "de"; 
                if (Program.langs[1] == "Español") url = "es"; 
                if (Program.langs[1] == "Français")url = "fr";
                Console.Clear();
                Console.WriteLine(Translate.write + Program.langs[0] + Translate.writeto + Program.langs[1]);
                Console.WriteLine(TranslateWord(Console.ReadLine(),url,auto));
                Console.ReadKey();
                Console.Clear();
            }
            if (y == 6) { Console.Clear(); YourLanguage.prap = true; Program.Main(null); }
            if (y == 7) { YourLanguage.lan(); Program.Main(null);}
            if (y == 8) { System.Environment.Exit(0); }
            if (y == 5) { ReadList(); YourLanguage.prap = false; Program.Main(null); }
            if (y == 3) { DeleteWord(); YourLanguage.prap = false; Program.Main(null); }
            if (y == 1) { Translate.translating();}
            if (y == 2) { Add.AddNewWords(); }

        }

        private static void DeleteWord() {
            Console.Clear();
            Console.WriteLine("\t\t\t" + Program.langs[0] + "    → to →    " + Program.langs[1]);
            string[] s = File.ReadAllLines(Program.way);
            Array.Sort(s);
            if (s == null || s.Length < 1) { Console.WriteLine("”Empty”"); 
                Console.ReadKey(true); Console.Clear(); return;
            }
            int y=Entering.Choose(s,1);
            StreamWriter sw = new StreamWriter(Program.way,false);
            foreach(var el in s) {
                if (el != s[y-1]) { sw.WriteLine(el); }
            }
            sw.Close();
        }

        private static void ReadList() {
            Console.Clear();
            Console.WriteLine("\t\t\t" + Program.langs[0] + "    → to →    " + Program.langs[1]);
            string[] s = File.ReadAllLines(Program.way);
            Array.Sort(s);
            if (s == null || s.Length < 1) { Console.WriteLine("”Empty”"); }
            foreach (var t in s) Console.WriteLine(t);
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
