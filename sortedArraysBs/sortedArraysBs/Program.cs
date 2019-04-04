using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortedArraysBs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Random rnd = new Random();
            int[] one = new int[250000];
            for(int i = 0; i < one.Length; i++)
            {
                int num = rnd.Next(100);
                one[i] = num;
            }
            Array.Sort(one);
            int[] two = new int[250000];
            for (int i = 0; i < two.Length; i++)
            {
                int num = rnd.Next(100);
                two[i] = num;
            }
            Array.Sort(two);
            List<int> intersectArr = arraysCommonalities(one, two);
            Console.WriteLine(DateTime.Now);
        }
        //0,0,0,0

        private static List<int> arraysCommonalities(int[] one, int[] two)
        {
            List<int> intersect = new List<int>();
            int i = 0, j = 0;
            while (i < one.Length && j < two.Length)
            {
                if (one[i] < two[j])
                    i++;
                else if (two[j] < one[i])
                    j++;
                else
                {
                    intersect.Add(two[j++]);
                    i++;
                }
            }
            return intersect;
        }
    }
}
