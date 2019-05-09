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
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(3);
            list.Insert(2,0);
            list.Add(4);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("I "+i+": "+list.Get(i));
            }
            Console.ReadLine();
        }
    }
}
