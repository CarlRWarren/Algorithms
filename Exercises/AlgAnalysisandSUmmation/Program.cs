using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgAnalysisandSUmmation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            int[] arr = new int[] { 1, 5, 7, 3, 9, 11, 22, 4 };
            int max = algorithm(arr);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now);
            func(arr);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine((Palindrome("tacocat"))? "It's a palindrome":"it's not a palindrome");

            arr = new int[] { 5, 2, 7, 2, 4, 7, 8, 2, 3 };
            distincts(arr);
        }
        static int algorithm(int[] a)
        {
            int x = a.Length - 1;
            int y = a[0];
            for (int i = 1; i < x; i++)
            {
                if (a[i] > y)
                {
                    y = a[i];
                }
            }
            return y;
        }

        static void func(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int mm = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > mm)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = mm;
            }
        }

        static bool Palindrome(string str)
        {
            bool palindrome = false;
            str = str.ToUpper();
            string str2 =str;
            str2.Reverse();
            if (str2.Equals(str))
            {
                palindrome = true;
            }
            return palindrome;
        }

        static void distincts(int[] array)
        {
            List<int> temp= new List<int>();
            for(int i=0; i<array.Length; i++)
            {
                if (!temp.Contains(array[i]))
                {
                    temp.Add(array[i]);
                }
            }
            foreach(var item in temp)
            {
                Console.Write(item+" ");
            }
        }
    }
}
