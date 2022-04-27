using entering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries {
    public static class YourLanguage {
        public static bool prap=true;
        public static string MenuLanguage="English";
        public static int position = 6;
        public static void lan() {
            Console.CursorVisible = false;
            prap = true;
            while (prap) {
                drawing(position);
                position=control(position);
            }
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            position -= 5;
            if(position<0)position+= Languages.languages.Count;
            if(position> Languages.languages.Count)position -= Languages.languages.Count;
            MenuLanguage = Languages.languages[position];
            Change();
            position -= 2;
            if (position < 0) position += Languages.languages.Count;
            if (position > Languages.languages.Count) position -= Languages.languages.Count;
        }

        private static void Change() {
            if (MenuLanguage == "English") {
                Program.toreverse = "to reverse languages";
                Enter.s =new string[] { "Translate", "Add new word(s)", "Delete word(s)", "Translate with Internet", "Take a look on list with all words", "Change languages", "Change menu language", "Exit" };
                Entering.aval = "(Is not avaliable)";
                Translate.quest= "Export to another file?";
                Translate.write = "Write ";
                Translate.writeto = " word to translate to ";
                Translate.Idon = "I don't know this word";
            }
            if (MenuLanguage == "Українська") {
                Program.toreverse = "поміняти мови місцями";
                Enter.s = new string[] { "Перекласти", "Додати нові слова","Видалити слова", "Перекласти за допомогою інтернету","Подивитись на список з всіма словами", "Вибрати інші мови", "Змінити мову меню", "Вийти" };
                Entering.aval = "(Недоступно)";
                Translate.quest = "Експортувати в окремий файл?";
                Translate.write = "Написати ";
                Translate.writeto =  " слово для перекладу на ";
                Translate.Idon = "Я не знаю цього слова";
            }
            if (MenuLanguage == "Русский") {
                Program.toreverse = "поменять языки местами";
                Enter.s = new string[] { "Перевести", "Добавить новые слова", "Удалить слова", "Перевести в интернете","Взглянуть на список со всеми словами", "Выбрать другие языки", "Изменить язык меню", "Выйти" };
                Entering.aval = "(Недоступно)";
                Translate.quest = "Експортировать в отдельный файл?";
                Translate.write = "Напишите ";
                Translate.writeto =  " слово, на которое нужно перевести ";
                Translate.Idon = "Я не знаю этого слова ";
            }
            if (MenuLanguage == "Polskie") {
                Program.toreverse = "zamień języki";
                Enter.s = new string[] { "Tłumaczyć", "Dodaj nowe słowa", "Usuń słowa", "Tłumacz przez Internet","Spójrz na listę ze wszystkimi słowami", "Wybierz inne języki", "Zmień język menu", "Wychodzić" };
                Entering.aval = "(Niedostępne)";
                Translate.quest = "Wyeksportować do osobnego pliku?";
                Translate.write = "Napisz ";
                Translate.writeto =  " słowo do przetłumaczenia na ";
                Translate.Idon = "nie znam tego słowa ";
            }
            if (MenuLanguage == "Deutsch") {
                Program.toreverse = "Sprachen tauschen";
                Enter.s = new string[] { "Übersetzen ", "Neue Wörter hinzufügen ", "Wörter löschen", "Online übersetzen ", "Schauen Sie auf die Liste mit allen Wörtern", "Andere Sprachen auswählen ", "Menüsprache ändern ", "Abmelden" };
                Entering.aval = "(Nicht verfügbar)";
                Translate.quest = "In eine separate Datei exportieren?";
                Translate.write = "Schreibe ";
                Translate.writeto =  " wort, das übersetzt werden soll ";
                Translate.Idon = "Ich kenne dieses Wort nicht ";
            }
            if (MenuLanguage == "Español") {
                Program.toreverse = "intercambiar idiomas";
                Enter.s = new string[] { "Traducir ", "Agregar nuevas palabras ", "Eliminar palabras", "Traducir en línea ", "Eche un vistazo a la lista con todas las palabras", "Elegir otros idiomas ", "Cambiar el idioma del menú ", "Cerrar sesión" };
                Entering.aval = "(No disponible)";
                Translate.quest = "¿Exportar a un archivo separado?";
                Translate.write = "Escribir " ;
                Translate.writeto = " palabra para traducir ";
                Translate.Idon = "No se esta palabra ";
            }
            if (MenuLanguage == "Français") {
                Program.toreverse = "échanger les langues";
                Enter.s = new string[] { "Traduire ", "Ajouter de nouveaux mots ", "Supprimer des mots", "Traduire en ligne ", "Jetez un œil à la liste avec tous les mots", "Choisir d'autres langues ", "Changer la langue du menu ", "Se déconnecter" };
                Translate.quest = "Exporter vers un fichier séparé?";
                Entering.aval = "(Pas disponible)";
                Translate.write = "Ecrire ";
                Translate.writeto = " mot à traduire en ";
                Translate.Idon = "je ne connais pas ce mot ";
            }
        }

        static void drawing(int position) {
            Console.Clear();
            int count = Languages.languages.Count;
            int numb = position;
            for (int i = 0; i < 5; i++) {
                if (i != 2) Console.ForegroundColor = ConsoleColor.DarkGray;
                else { Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.SetCursorPosition(20,4+i*2);
                Console.Write(Languages.languages[numb]);
                numb++;
                if (numb >= count) numb = 0;
                if (i == 2) {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        private static int control(int pos) {
            ConsoleKeyInfo cki;
            int count = Languages.languages.Count;
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.DownArrow) {
                pos++; if (pos >= count) { pos = 0; }
            }
            if (cki.Key == ConsoleKey.UpArrow) {
                pos--; if (pos < 0) { pos = count - 1; }
            }
            if (cki.Key == ConsoleKey.Enter || cki.Key == ConsoleKey.Spacebar) { prap = false; }
            return pos;
        }
    }
}
