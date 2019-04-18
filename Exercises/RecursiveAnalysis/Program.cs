using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 1, 5, 3, 4, 3, 6 };
            z(arr,0,arr.Length);
        }
        /*1. Get the following code working in C# (or Java)

2. Debug, set breakpoints, step through, analyze, and understand...

3. Write a few sentences explaining what this algorithm does. 
(If you see a common approach, logic, pattern, or outcome from this algorithm, (compared to others you may be already be familiar with), 
please explain any similarities or differences that you noted.)No code submission required - just a few sentences explaining your analysis.*/
        static void z(int[] arr, int startindex, int endindex)
        {
            foreach(int item in arr)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            if (startindex >= endindex)
                return;
            int minindex;
            int temp;

            /* Assume minIndex() returns the index of the minimum value in the array arr -> you will need to write a minIndex function to do this*/
            minindex = minIndex(arr, startindex, endindex);

            temp = arr[startindex];
            arr[startindex] = arr[minindex];
            arr[minindex] = temp;

            z(arr, startindex + 1, endindex);
        }

        private static int minIndex(int[] arr, int startindex, int endindex)
        {
            int index = int.MaxValue;
            int min = int.MaxValue;
            for(int i = startindex; i<endindex; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
