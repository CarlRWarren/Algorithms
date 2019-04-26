using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        public static int n=0;
        public static int steps = 0;
        public static int[,] solution = null;
        public static int numberSolutions = 0;
        static void Main(string[] args)
        {
            while (n <= 0 || n >= int.MaxValue)
            {
                Console.WriteLine("Enter a positive non-zero integer");
                int.TryParse(Console.ReadLine(), out n);
            }
            solution = new int[n,n];
            ResetBoard();
            if (!theBoardSolver(0))
            {
                Console.WriteLine("Solution not found.");
            }
            Console.WriteLine("n: "+n);
            Console.WriteLine("Number of Solutions: " +numberSolutions);
            PrintSolution();
            Console.ReadLine();
        }

        private static bool PlaceAQueen(int row, int col)
        {
            //steps++;
            int i, j;
            for (i = 0; i < col; i++)
            {
                if (solution[row, i] == 1) return false;
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (solution[i, j] == 1) return false;
            }
            for (i = row, j = col; j >= 0 && i < n; i++, j--)
            {
                if (solution[i, j] == 1) return false;
            }
            return true;
        }

        static bool theBoardSolver(int col)
        {
            //9steps++;

            if (col >= n) return true;
            //8steps++;
            for (int i = 0; i < n; i++)
            {
                //26steps++;

                if (PlaceAQueen(i, col))
                {
                    //8steps++;

                    solution[i, col] = 1;
                    if (theBoardSolver(col + 1)) return true;
                    solution[i, col] = 0;
                    //4steps++;
                }
                //22steps++;
            }
            //4steps++;
            return false;
        }
        public static void PrintSolution()
        {
            Console.WriteLine("Steps: "+steps);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(solution[i, j]); 
                }
                Console.WriteLine();
            }
        }

        private static void ResetBoard()
        {
            steps = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    solution[i, j] = 0;
                }
            }
        }
    }
}
