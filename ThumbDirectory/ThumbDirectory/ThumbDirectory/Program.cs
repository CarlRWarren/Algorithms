using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThumbDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Phone("/+1-541-754-3010 156 Alphand_St. <J Steeve>\n", "1-541-754-3010"));
        }
        public static string Phone(string strng, string num)
        {
            string result = "";
            string[] lines = strng.Split('\n');
            foreach(string line in lines)
            {
                Console.WriteLine(line);
                Regex numReg = new Regex($"{num}");
                Console.WriteLine(numReg);

                MatchCollection matches = numReg.Matches(line);
                if(matches.Count != 0)
                {
                    Regex nameReg = new Regex(@"<[\w\s]+>");
                    MatchCollection nameMatches = nameReg.Matches(line);
                    if (nameMatches.Count > 1)
                    {
                        result = "Error => Too many people: nb";
                    }
                    else
                    {
                        string name = "";
                        foreach(var mc in nameMatches)
                        {
                            //mc[]
                        }
                        result = $"Phone => {num}, Name => {name}";
                    }

                }
                else
                {
                    result = "Error => Not Found: nb";
                }
            }
            //MatchCollection matches = nameReg.Matches(testStr);
            //Console.WriteLine(matches.Count);
            return result;
        }
    }
}
