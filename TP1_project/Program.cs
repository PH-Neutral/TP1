using System;
using System.Collections.Generic;

namespace TP1_project {
    class Program {
        static void Main(string[] args) {

            string test = "a*65*-*hrt-p**tttr";
            Console.WriteLine(test + "\n<start: Split>");
            string[] splited = Split('*', test).ToArray();
            foreach(string str in splited) {
                Console.WriteLine(str);
            }
            Console.WriteLine("<end: Split>\n");

            Console.WriteLine("<start: Invert>");
            string test2 = "azerty";
            Console.WriteLine(test2 + ": [" + Invert(test2) + "]");
            Console.WriteLine("<end: Invert>\n");

            Console.WriteLine("<start: InvertWords>");
            string test3 = "j'écris une phrase";
            Console.WriteLine(test3 + ": [" + InvertWords(test3) + "]");
            Console.WriteLine("<end: InvertWords>\n");

            Console.WriteLine("<start: InvertSentence>");
            string test4 = "je m'amuse à programmer en C#";
            Console.WriteLine(test4 + ": [" + InvertSentence(test4) + "]");
            Console.WriteLine("<end: InvertSentence>\n");

            Console.WriteLine("<start: GetIndexSmaller>");
            int[] test5 = new int[] { -99, 81, 5, 6, -150, 0 };
            Console.WriteLine("{ 0:-99, 1:81, 2:5, 3:6, 4:-150, 5:0 }" + ": [" + GetIndexSmaller(test5) + "]");
            Console.WriteLine("<end: GetIndexSmaller>\n");
        }

        /** <summary>Renvoie une liste de sous-chaîne de characters où chaque sous-chaîne est comprise entre un séparateur.</summary>**/
        static List<string> Split(char separator, string str) {
            List<string> result = new List<string>();
            string substring = "";
            for(int i=0;i<str.Length;i++) {
                if (str[i] == separator) {
                    result.Add(substring);
                    substring = "";
                } else {
                    substring += str[i];
                }
            }
            result.Add(substring);
            return result;
        }

        static string Invert(string str) {
            string result = "";
            for (int i=str.Length - 1; i >= 0; i--) {
                result += str[i];
            }
            return result;
        }

        static string InvertWords(string str) {
            string result = "";
            string[] words = Split(' ', str).ToArray();
            for (int i=0; i<words.Length; i++) {
                result += Invert(words[i]) + (i < words.Length - 1 ? " " : "");
            }
            return result;
        }

        static string InvertSentence(string str) {
            string result = "";
            string[] words = Split(' ', str).ToArray();
            for(int i = words.Length - 1; i >= 0; i--) {
                result += words[i] + (i > 0 ? " " : "");
            }
            return result;
        }

        static int GetIndexSmaller(int[] array) {
            int index = -1;
            int min = int.MaxValue;
            for (int i=0;i<array.Length; i++) {
                if (array[i] < min) {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
