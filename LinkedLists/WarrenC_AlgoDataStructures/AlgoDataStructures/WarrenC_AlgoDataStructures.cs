using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T>
    {
        Node head;
        public int Count { get; set; } = 0;
        List<Node> nodes = new List<Node>();        

        public class Node
        {
            public T data;
            public Node next;
            public Node(T d) { data = d; next = null; }
        }

        public void Add(T val)
        {
            Node new_node = new Node(val);
            Count++;
            if (Count == 1)
            {
                head = new_node;
            }
            else
            {
                nodes[Count - 2].next = new_node;
            }
            nodes.Add(new_node);
        }

        public void Insert(T val, int index)
        {
            if (index >= 0 && index < nodes.Count)
            {
                Count++;
                Node prevNode = nodes[index];
                Node node = new Node(val);
                Node tail = nodes[nodes.Count-1];
                for(int i = index; i < Count; i++)
                {
                    nodes[i] = node;
                    node.next = prevNode;
                    node = prevNode;
                    if(i< Count - 2)
                    {
                        prevNode = nodes[i + 1];
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
                value= nodes[Count-1].data;
                nodes.RemoveAt(Count-1);
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
            int index=-1;
            for (int i=0; i < Count; i++)
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
            for(int i = 0; i < nodes.Count; i++)
            {
                str+=nodes[i].ToString();
            }
            return str;
        }
    }

}
