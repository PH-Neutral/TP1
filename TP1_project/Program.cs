using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;

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

            Console.WriteLine("<start: SortBubble>");
            int[] test6 = new int[] { -99, 81, 5, 6, -150, 0 };
            int[] bubbleExit = SortBubble(test6);
            foreach (int value in bubbleExit)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("<end: SortBubble>\n");

            Console.WriteLine("<start: SortInsertion>");
            int[] test7 = new int[] { -99, 81, 5, 6, -150, 0 };
            int[] insertionExit = SortInsertion(test7);
            foreach (int value in insertionExit)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("<end: SortInsertion>\n");

            Console.WriteLine("<start: Fusion>");
            List<int> test8_1 = new List<int> { 0, 2, 4, 6 };
            List<int> test8_2 = new List<int> { 1, 3, 5, 7 };
            List<int> test8_3 = Fusion(test8_1, test8_2);
            foreach (int value in test8_3)
            {
                Console.WriteLine(value);
            }


            Console.WriteLine("<end: Fusion>\n");
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

        static int[] SortBubble(int[] array)
        {
            bool modified;
            do
            {
                modified = false;
                for (int i = 0; i < array.Length -1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        modified = true;
                    }
                }
            } while (modified);

            return array;
        }

        static int[] SortInsertion(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }

            }
            return array;
        }

        static List<int> Fusion(List<int> array1, List<int> array2)
        {
            if (array1.Count == 0)
            {
                return array2;
            }

            if (array2.Count == 0)
            {
                return array1;
            }
            List<int> result = new List<int>();
            if (array1[0] <= array2[0])
            {
                result.Add(array1[0]);
                result.AddRange(Fusion(array1.GetRange(1,array1.Count -1),array2));
            }
            else
            {
                result.Add(array2[0]);
                result.AddRange(Fusion(array2.GetRange(1, array2.Count - 1), array1));
            }
            return result;
        }
    }
}
