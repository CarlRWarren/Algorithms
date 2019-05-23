using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDataStructures;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(4);
            Console.WriteLine("Added 4");
            tree.Add(2);
            Console.WriteLine("Added 2");
            tree.Add(1);
            Console.WriteLine("Added 1");
            tree.Add(5);
            Console.WriteLine("Added 5");
            tree.Add(2);
            Console.WriteLine("Added 2");
            Console.WriteLine(tree.Count);
            int[] stuff = tree.ToArray();
            for(int i= 0; i < stuff.Length;i++)
            {
                Console.Write(stuff[i]+" ");
            }
        }
    }
}
