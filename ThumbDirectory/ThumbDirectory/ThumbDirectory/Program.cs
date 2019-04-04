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
            Console.WriteLine(Phone("<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n", "+1-121-504-8974"));
        }
        public static string Phone(string strng, string num)
        {
            string result = "";
            string[] lines = strng.Split('\n');
            foreach(string line in lines)
            {
                bool found = false;
                if(line != "")
                {
                    Regex numReg = new Regex($"\\{num}");
                    MatchCollection matches = numReg.Matches(line);
                    if(matches.Count != 0)
                    {
                        found = true;
                        Regex nameReg = new Regex(@"<[\w\s]+>");
                        MatchCollection nameMatches = nameReg.Matches(line);
                        if (nameMatches.Count > 1)
                        {
                            result = "Error => Too many people: nb";
                        }
                        else
                        {
                            string name = "";
                            name = nameMatches[0].Groups[0].Value;
                            string address = line.Replace(num, "");
                            address = address.Replace(name, "");
                            address = address.Trim(new Char[] { '$', '/', ':', ';'});
                            //Regex addReg = new Regex(@"[\w\d\s]+");
                            //MatchCollection addMatches = addReg.Matches(address);
                            name = name.Trim(new Char[] { '<', '>' });
                            result = $"Phone => {num}, Name => {name}, Address => {address.Trim()}";
                        }
                    }
                    else
                    {
                        result = "Error => Not Found: nb";
                    }
                }
                if (found)
                {
                    break;
                }
            }
            return result;
        }
    }
}
