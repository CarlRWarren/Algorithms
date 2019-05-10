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
            Console.WriteLine("List is newed");
            list.Add(1);
            Console.WriteLine("added 1");
            list.Insert(2, 0);
            Console.WriteLine("inserted 2 at beginning");

            list.Add(5);
            Console.WriteLine("added 5");

            //list.Add(3);
            //list.Insert(2,0);
            //list.Add(4);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("list at i "+i+": "+list.Get(i));
            }
            Console.ReadLine();
        }
    }
}
/*public class DoubleLinkedList<T>
    {
        Node head;
        public int Count { get; set; } = 0;
        List<Node> nodes = new List<Node>();

        public class Node
        {
            public T data;
            public Node next;
            public Node prev;
            public Node(T d) { data = d; next = null; prev = null; }
        }

        public void Add(T val)
        {

            Node prevNode;
            Node new_node = new Node(val);
            Count++;
            if (Count == 1)
            {
                prevNode = null;
                head = new_node;
                head.prev = prevNode;
            }
            else
            {
                prevNode = nodes[Count - 1];
                nodes[Count - 2].next = new_node;
                nodes[Count - 2].prev = prevNode;
            }
            nodes.Add(new_node);
        }

        public void Insert(T val, int index)
        {
            if (index >= 0 && index < nodes.Count)
            {
                Count++;
                Node nextNode = nodes[index];
                Node prevNode;
                Node node = new Node(val);
                Node tail = nodes[nodes.Count - 1];
                for (int i = index; i < Count; i++)
                {
                    if (i - 1 > 0)
                    {
                        prevNode = nodes[i - 1];
                    }
                    else
                    {
                        prevNode = null;
                    }
                    nodes[i] = node;
                    node.next = nextNode;
                    node.prev = prevNode;
                    node = nextNode;
                    if (i < Count - 2)
                    {
                        nextNode = nodes[i + 1];
                    }
                    else
                    {
                        nodes.Add(tail);
                        nodes[Count - 1].next = null;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }

        }

        public T Get(int index)
        {
            T value;
            if (index >= 0 && index < nodes.Count)
            {
                value = nodes[index].data;
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }
            return value;
        }

        public T RemoveAt(int index)
        {
            T value;
            if (index >= 0 && index < nodes.Count)
            {
                value = nodes[index].data;
                nodes.RemoveAt(index);
                Count--;
                if (index > 0)
                {
                    nodes[index - 1].next = (index + 1 < Count) ? nodes[index + 1] : null;
                }
                else
                {
                    head.next = (index + 1 < Count) ? nodes[index + 1] : null;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }
            return value;
        }

        public T Remove()
        {
            T value = nodes[0].data;
            nodes.RemoveAt(0);
            Count--;
            if (Count > 0)
            {
                head.next = nodes[0];
            }
            else
            {
                head.next = null;
            }
            return value;
        }

        public T RemoveLast()
        {
            T value = default(T);
            if (Count != 0)
            {
                value = nodes[Count - 1].data;
                nodes.RemoveAt(Count - 1);
                Count--;
                if (Count > 1)
                {
                    nodes[Count - 1].next = null;
                }
                else
                {
                    head.next = null;
                }
            }
            return value;
        }

        public void Clear()
        {
            nodes.Clear();
            head = null;
            Count = 0;
        }

        public int Search(T val)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (nodes[i].data.Equals(val))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < nodes.Count; i++)
            {
                str += nodes[i].ToString();
            }
            return str;
        }
    }
}*/
