using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flood
{
    class Program
    {
        static void Main(string[] args)
        {
            var expected = new int[,]
              {{1,4,3},
               {1,4,4},
               {2,3,4}};
            Print(expected, "Expected");

            var actual = new int[,]
              {{1,2,3},
               {1,2,2},
               {2,3,2}};
            Print(actual, "Before fill");
            FloodFill(actual, 0, 1, 4);
            Print(actual, "After fill");
        }

        public static void Print(int[,] arr, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i <= arr.GetLength(0)-1; i++)
            {
                for (int j = 0; j <= arr.GetLength(1)-1; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int[,] FloodFill(int[,] array, int y, int x, int newValue)
        {
            int posVal = array[y, x];
            array[y, x] = newValue;
            ChangeAdjacents(ref array, y, x, newValue, posVal);
            return array;
        }

        public static void ChangeAdjacents(ref int[,] arr, int y, int x, int newVal, int oldVal)
        {
            arr[y, x] = newVal;
            if (y != 0 && arr[y - 1, x] == oldVal)
            {
                ChangeAdjacents(ref arr, y - 1, x, newVal, oldVal);
            }
            if (x != 0 && arr[y, x - 1] == oldVal)
            {
                ChangeAdjacents(ref arr, y, x - 1, newVal, oldVal);
            }
            if (y < arr.GetLength(0) - 1 && arr[y + 1, x] == oldVal)
            {
                ChangeAdjacents(ref arr, y + 1, x, newVal, oldVal);
            }
            if (x < arr.GetLength(1) - 1 && arr[y, x + 1] == oldVal)
            {
                ChangeAdjacents(ref arr, y, x + 1, newVal, oldVal);
            }
        }
    }
}
