using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Dictionaries {
    class Program {
        public static string[] langs;
        public static string way;
        public static int variant;
        public static int first;
        public static string toreverse= "to reverse languages";
        public static void Main(string[] args) {
            first = -1;
            string[] u = Directory.GetFiles("Directory");
            foreach(var el in u) {
                string f=File.ReadAllText(el);
                if (f == null || f.Length < 3) {
                    File.Delete(el);
                }
            }
            Settings.SetStart();
            if (YourLanguage.prap) langs = Languages.ChoosingLanguage();
            while (true) {
                Console.Clear();
                Console.WriteLine("\t\t\t" + langs[0] + "    → to →    " + langs[1]);
                Console.SetCursorPosition(40, 14);
                Console.Write("'R' - " + toreverse);
                Console.SetCursorPosition(0, 1);
                if (first != 1) FindWay();
                Enter.ChooseWorkToDo();
            }
        }
        
        public static void FindWay() {
            variant = 1;
            if (!Directory.Exists("Directory")) {
                Directory.CreateDirectory("Directory");
            }
            if (File.Exists("Directory\\" + langs[1] + langs[0] + ".txt")) {
                variant = 2;
                Enter.prap = true;
            }
            else if (!File.Exists("Directory\\" + langs[0] + langs[1] + ".txt")) {
                File.Create("Directory\\" + langs[0] + langs[1] + ".txt").Close();
                Enter.prap = false;
            }
            else {
                Enter.prap = true;
            }
            if (variant == 1) { way = "Directory\\" + langs[0] + langs[1] + ".txt"; }
            else { way = "Directory\\" + langs[1] + langs[0] + ".txt"; }
        }
    }
}
