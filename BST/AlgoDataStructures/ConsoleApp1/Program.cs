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
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            Console.WriteLine("Created");
            tree.Add(0);
            Console.WriteLine("Added root:");
            tree.Add(2);
            Console.WriteLine("Added right:");
            tree.Add(1);
            tree.Add(2);
            Console.WriteLine(tree.Count);
        }
    }
}
