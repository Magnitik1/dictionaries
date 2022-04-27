using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries {
    class Add {
        public static void AddNewWords() {
            string way = Program.way;
            int variant = Program.variant;
            Console.Clear();
            string[] langs = Program.langs;
            Console.WriteLine("Word on " + langs[0]);
            string word1 = Console.ReadLine();
            if (word1 == "") return;
            Console.WriteLine("Word on " + langs[1]);
            string word2 = Console.ReadLine();
            if (word2 == "") return;
            StreamReader sr = new StreamReader(way);
            List<string> arr = new List<string>();
            while (true) {
                string temp = sr.ReadLine();
                if (temp == null) break;
                arr.Add(temp);
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(way,true);
            if (variant == 1) {
                if (arr.Contains(word1 + " - " + word2)) { sw.Close();AddNewWords(); return; }
                sw.WriteLine(word1 + " - " + word2);
            }
            else if (variant == 2) {
                if (arr.Contains(word2 + " - " + word1)) { sw.Close();AddNewWords(); return; }
                sw.WriteLine(word2 + " - " + word1);
            }
            sw.Close();
            AddNewWords();
        }
    }
}
