using System;
using System.Collections.Generic;
using System.Globalization;

namespace TP1_project {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("<start: Split>");
            string test1 = "a*65*-*hrt-p**tttr";
            Console.WriteLine("string: [" + test1 + "]");
            string[] test1bis = Split('*', test1).ToArray();
            foreach(string str in test1bis) {
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

            Console.WriteLine("<start: TriInsertion>");
            int[] test7 = new int[] { -99, 81, 5, 6, -150, 0 };
            int[] test7bis = TriInsertion(test7);
            string test7Result = "{ ";
            for(int i=0; i < test7bis.Length; i++) {
                test7Result += test7bis[i] + (i < test7bis.Length - 1 ? ", " : " }");
            }
            Console.WriteLine("array: { -99, 81, 5, 6, -150, 0 } => " + test7Result);
            Console.WriteLine("<end: TriInsertion>\n");

            Console.WriteLine("<start: TriFusion>");
            List<int> test8 = new List<int> { -99, 81, 5, 6, -150, 0 };
            List<int> test8bis = TriFusion(test8);
            string test8Result = "{ ";
            for(int i = 0; i < test8bis.Count; i++) {
                test8Result += test8bis[i] + (i < test8bis.Count - 1 ? ", " : " }");
            }
            Console.WriteLine("array: { -99, 81, 5, 6, -150, 0 } => " + test8Result);
            Console.WriteLine("<end: TriFusion>\n");
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

        static int[] TriInsertion(int[] array) {
            for (int i=1; i < array.Length; i++) {
                for(int j = i; j > 0; j--) {
                    if (array[j-1] > array[j]) {
                        int temp = array[j-1];
                        array[j-1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        static List<int> Fusion(List<int> list1, List<int> list2) {
            if (list1.Count == 0) { return list2; }
            if (list2.Count == 0) { return list1; }
            List<int> result = new List<int>();
            if (list1[0] <= list2[0]) {
                result.Add(list1[0]);
                result.AddRange( Fusion( list1.GetRange(1, list1.Count - 1), list2 ) );
            } else {
                result.Add(list2[0]);
                result.AddRange(Fusion(list1, list2.GetRange(1, list2.Count - 1)));
            }
            return result;
        }

        static List<int> TriFusion(List<int> list) {
            if (list.Count <= 1) { 
                return list; 
            }
            else {
                int halfCount = list.Count / 2;
                return Fusion(TriFusion(list.GetRange(0, halfCount)), TriFusion(list.GetRange(halfCount, list.Count - halfCount)));
            }
        }
    }
}
