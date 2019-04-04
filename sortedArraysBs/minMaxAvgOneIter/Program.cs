using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minMaxAvgOneIter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 8, 3, 7, 4, 11, 4, 4, 66, 10, 3, 2 };
            int max = 0;
            int min = int.MaxValue;
            int sum = 0;
            float avg;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                sum += numbers[i];
            }
            avg = sum / numbers.Length;
            Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg} ");
        }
    }
}
