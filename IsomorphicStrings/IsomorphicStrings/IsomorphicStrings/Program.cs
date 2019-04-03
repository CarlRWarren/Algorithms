using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsomorphicStrings
{
    class Program
    {
        public Dictionary<string, List<string>> exactIsomorphs = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> looseIsomorphs = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> nonIsomorphs = new Dictionary<string, List<string>>();
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
            DetermineNons(wordsFromFile);
        }

        static void DetermineExacts(string[] words)
        {
            List<string> exactKeys = null;
            Dictionary<string, List<string>> keyToWord = null;
            foreach (string word in words)
            {
                string key = DetermineExactKey(word) + ":";
                if (!exactKeys.Contains(key))
                {
                    exactKeys.Add(key);
                }
                keyToWord[key].Add(word);
            }
        }

        static string DetermineExactKey(string word)
        {
            string key = "";
            int index = 0;
            List<char> letters = null;
            foreach(char letter in word)
            {
                if (!letters.Contains(letter))
                {
                    letters.Add(letter);
                    key += index;
                    index++;
                }
                else
                {
                    key += index;
                }
            }
            return key;
        }

        static void DetermineLoose(string[] words)
        {
            foreach (string word in words)
            {

            }
        }

        static void DetermineNons(string[] words)
        {
            foreach (string word in words)
            {

            }
        }
    }
}
