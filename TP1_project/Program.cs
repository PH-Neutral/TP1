using System;
using System.Collections.Generic;

namespace TP1_project {
    class Program {
        static void Main(string[] args) {
            WriteLineColored("** Travail Pratique 1 - Coding/Scripting 1ère Année **\n", ConsoleColor.Cyan);

            // split method
            WriteLineColored("<Split>");
            string split = "start*with spaces inside*symbøl€$_^^*420**end";
            List<string> splitExit = Split('*', split);
            Console.WriteLine("[" + split + "] => " + ToString(splitExit));
            WriteLineColored("</Split>\n");

            // invert method
            WriteLineColored("<Invert>");
            string invert = "invert this!";
            string invertExit = Invert(invert);
            Console.WriteLine("[" + invert + "] => [" + invertExit + "]");
            WriteLineColored("</Invert>\n");

            // invertWords method
            WriteLineColored("<InvertWords>");
            string invertWords = "cette phrase va finir inversée";
            string invertWordsExit = InvertWords(invertWords);
            Console.WriteLine("[" + invertWords + "] => [" + invertWordsExit + "]");
            WriteLineColored("</InvertWords>\n");

            // invertSentence method
            WriteLineColored("<InvertSentence>");
            string invertSentence = "je m'amuse à programmer en C#";
            string invertSentenceExit = InvertSentence(invertSentence);
            Console.WriteLine("[" + invertSentence + "] => [" + invertSentenceExit + "]");
            WriteLineColored("</InvertSentence>\n");

            // getIndexSmaller method
            WriteLineColored("<GetIndexSmaller>");
            int[] getIndexSmaller = new int[] { -99, 81, 5, 6, -150, 0 };
            int getIndexSmallerExit = GetIndexSmaller(getIndexSmaller);
            Console.WriteLine(ToString(getIndexSmaller) + " => [" + getIndexSmallerExit + "]");
            WriteLineColored("</GetIndexSmaller>\n");

            // triBulles method
            WriteLineColored("<TriBulles>");
            int[] bubbles = new int[] { -99, 81, 5, 6, -150, 0 };
            int[] bubblesExit = TriBulles(bubbles);
            Console.WriteLine(ToString(bubbles) + " => " + ToString(bubblesExit));
            WriteLineColored("</TriBulles>\n");

            // triInsertion method
            WriteLineColored("<TriInsertion>");
            int[] insertion = new int[] { -99, 81, 5, 6, -150, 0 };
            int[] insertionExit = TriInsertion(insertion);
            Console.WriteLine(ToString(insertion) + " => " + ToString(insertionExit));
            WriteLineColored("</TriInsertion>\n");

            // fusion method
            WriteLineColored("<Fusion>");
            List<int> fusion1 = new List<int> { 0, 2, 4, 6 };
            List<int> fusion2 = new List<int> { 1, 3, 5, 7 };
            List<int> fusionExit = Fusion(fusion1, fusion2);
            Console.WriteLine(ToString(fusion1) + " + " + ToString(fusion2) + " => " + ToString(fusionExit));
            WriteLineColored("</Fusion>\n");

            // triFusion method
            WriteLineColored("<TriFusion>");
            List<int> sortFusion = new List<int> { -99, 81, 5, 6, -150, 0 };
            List<int> sortFusionExit = TriFusion(sortFusion);
            Console.WriteLine(ToString(sortFusion) + " => " + ToString(sortFusionExit));
            WriteLineColored("</TriFusion>\n");
        }

        /** <summary>Renvoie une liste de sous-chaîne de characters où chaque sous-chaîne est comprise entre un séparateur.</summary>**/
        static List<string> Split(char separator, string str) {
            List<string> result = new List<string>();
            string substring = "";
            for(int i = 0; i < str.Length; i++) {
                if(str[i] == separator) {
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
            for(int i = str.Length - 1; i >= 0; i--) {
                result += str[i];
            }
            return result;
        }

        static string InvertWords(string str) {
            string result = "";
            string[] words = Split(' ', str).ToArray();
            for(int i = 0; i < words.Length; i++) {
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
            for(int i = 0; i < array.Length; i++) {
                if(array[i] < min) {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }

        static int[] TriBulles(int[] array) {
            bool modified;
            do {
                modified = false;
                for(int i = 0; i < array.Length - 1; i++) {
                    if(array[i] > array[i + 1]) {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        modified = true;
                    }
                }
            } while(modified);

            return array;
        }

        static int[] TriInsertion(int[] array) {
            for(int i = 1; i < array.Length; i++) {
                for(int j = i; j > 0; j--) {
                    if(array[j - 1] > array[j]) {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }

            }
            return array;
        }

        static List<int> Fusion(List<int> array1, List<int> array2) {
            if(array1.Count == 0) {
                return array2;
            }

            if(array2.Count == 0) {
                return array1;
            }
            List<int> result = new List<int>();
            if(array1[0] <= array2[0]) {
                result.Add(array1[0]);
                result.AddRange(Fusion(array1.GetRange(1, array1.Count - 1), array2));
            } else {
                result.Add(array2[0]);
                result.AddRange(Fusion(array2.GetRange(1, array2.Count - 1), array1));
            }
            return result;
        }

        static List<int> TriFusion(List<int> list) {
            if(list.Count <= 1) {
                return list;
            } else {
                int halfCount = list.Count / 2;
                return Fusion(TriFusion(list.GetRange(0, halfCount)), TriFusion(list.GetRange(halfCount, list.Count - halfCount)));
            }
        }

        // ----- Testing utilities ----- //

        static void WriteLineColored(string str, ConsoleColor foregroundColor = ConsoleColor.DarkYellow) {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        static string ToString(List<int> intList) => ToString(intList.ToArray());
        static string ToString(int[] intArray) {
            string[] strArray = new string[intArray.Length];
            for(int i = 0; i < intArray.Length; i++) {
                strArray[i] = "" + intArray[i];
            }
            return ToString(strArray);
        }

        static string ToString(List<string> strList) => ToString(strList.ToArray());
        static string ToString(string[] array) {
            string result = "{";
            for(int i = 0; i < array.Length; i++) {
                result += '[' + array[i] + ']' + (i < array.Length - 1 ? ", " : "}");
            }
            return result;
        }
    }
}
