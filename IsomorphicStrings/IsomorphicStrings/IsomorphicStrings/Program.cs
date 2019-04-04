using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsomorphicStrings
{
    class Program
    {
        static Dictionary<string, List<string>> exactIsomorphs = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> looseIsomorphs = new Dictionary<string, List<string>>();
        static List<List<string>> nonIsomorphs = new List<List<string>>();
        static void Main(string[] args)
        {
            ReadFile();
        }

        static void ReadFile()
        {
            Console.WriteLine("What is the file path?");
            string filePath = Console.ReadLine();
            string[] wordsFromFile = System.IO.File.ReadAllLines(@filePath);
            DetermineExacts(wordsFromFile);
            DetermineLoose(wordsFromFile);
            Print();
        }
        //C:\Users\Carl\OneDrive - Neumont University\q7\Algorithms\IsomorphicStrings\IsomorphInput1.txt
        private static void Print()
        {
            List<string> output = new List<string>();
            Console.WriteLine("Exact Isomorphs");
            output.Add("Exact Isomorphs");
            string line = "";
            foreach(string key in exactIsomorphs.Keys)
            {
                line = "";
                line += key + " ";
                for (int i=0; i<exactIsomorphs[key].Count(); i++)
                {
                    if(i!= exactIsomorphs[key].Count() - 1)
                    {
                        line += exactIsomorphs[key][i] + " ";
                    }
                    else
                    {
                        line += exactIsomorphs[key][i];
                    }
                }
                Console.Write(line);
                output.Add(line);
                Console.WriteLine();
            }
            output.Add("");
            Console.WriteLine();
            Console.WriteLine("Loose Isomorphs");
            output.Add("Loose Isomorphs");
            foreach (string key in looseIsomorphs.Keys)
            {
                line = "";
                line += key + " ";
                for (int i = 0; i < looseIsomorphs[key].Count(); i++)
                {
                    if (i != looseIsomorphs[key].Count() - 1)
                    {
                        line+=looseIsomorphs[key][i] + " ";
                    }
                    else
                    {
                        line+=looseIsomorphs[key][i];
                    }
                }
                Console.Write(line);
                output.Add(line);
                Console.WriteLine();
            }
            Console.WriteLine();
            output.Add("");
            Console.WriteLine("Non-Isomorphs");
            output.Add("Non-Isomorphs");
            line = "";
            foreach(var words in nonIsomorphs)
            {
                foreach(string word in words){
                    line += word;
                }
                if (words != nonIsomorphs.Last())
                {
                    line += " ";
                }
            }
            Console.Write(line);
            output.Add(line);
            System.IO.File.WriteAllLines("Output.txt",output.ToArray());//goes to the projects bin's debug folder
        }

        static void DetermineExacts(string[] words)
        {
            List<string> exactKeys = new List<string>();
            Dictionary<string, List<string>> keyToWords = new Dictionary<string, List<string>>();
            foreach (string word in words)
            {
                string key = DetermineExactKey(word) + ":";
                if (!exactKeys.Contains(key))
                {
                    exactKeys.Add(key);
                }
                if (keyToWords.ContainsKey(key))
                {
                    keyToWords[key].Add(word);
                }
                else
                {
                    keyToWords.Add(key, new List<string>());
                    keyToWords[key].Add(word);
                }
            }
            foreach(string key in keyToWords.Keys)
            {
                if (keyToWords[key].Count > 1)
                {
                    exactIsomorphs[key] = keyToWords[key];
                }
            }
        }

        static string DetermineExactKey(string word)
        {
            string key = "";
            int index = 0;
            List<char> letters = new List<char>();
            foreach(char letter in word)
            {
                if (!letters.Contains(letter))
                {
                    letters.Add(letter);
                }
            }
            int[] indexes = new int[word.Length];
            char[] characters = word.ToCharArray();
            foreach(char letter in letters)
            {
                for (int i = 0; i<word.Length; i++)
                {
                    if (characters[i] == letter)
                    {
                        indexes[i] = index;
                    }
                }
                index++;
            }
            for (int i = 0; i < indexes.Count(); i++)
            {
                key += indexes[i];
                if (i != indexes.Count()-1)
                {
                    key += " ";
                }
            }

            return key;
        }

        static void DetermineLoose(string[] words)
        {
            List<string> looseKeys = new List<string>();
            Dictionary<string, List<string>> keyToWords = new Dictionary<string, List<string>>();
            foreach (string word in words)
            {
                string key = DetermineLooseKey(word) + ":";
                if (!looseKeys.Contains(key))
                {
                    looseKeys.Add(key);
                }
                if (keyToWords.ContainsKey(key))
                {
                    keyToWords[key].Add(word);
                }
                else
                {
                    keyToWords.Add(key, new List<string>());
                    keyToWords[key].Add(word);
                }
            }
            foreach (string key in keyToWords.Keys)
            {
                if (keyToWords[key].Count > 1)
                {
                    looseIsomorphs[key] = keyToWords[key];
                }
                else
                {
                    nonIsomorphs.Add(keyToWords[key]);
                }
            }
        }

        static string DetermineLooseKey(string word)
        {
            string key = "";
            int index = 0;
            List<char> letters = new List<char>();
            int count = 0;
            foreach (char letter in word)
            {
                if (!letters.Contains(letter))
                {
                    letters.Add(letter);
                }
            }
            int[] indexes = new int[letters.Count];
            char[] characters = word.ToCharArray();
            foreach (char letter in letters)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (characters[i] == letter)
                    {
                        count++;
                    }
                }
                indexes[index]=count;
                count = 0;
                index++;
            }
            Array.Sort(indexes);
            for (int i = 0; i < indexes.Count(); i++)
            {
                key += indexes[i];
                if (i != indexes.Count() - 1)
                {
                    key += " ";
                }
            }
            return key;
        }
    }
}
