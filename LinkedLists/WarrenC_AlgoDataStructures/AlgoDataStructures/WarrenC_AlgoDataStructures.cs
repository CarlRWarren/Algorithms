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

        public class Node
        {
            public T data;
            public Node next;
            public Node(T d) { data = d; next = null; }
        }

        public void Add(T val)
        {
            Count++;
            Node new_node = new Node(val);
            if (head == null)
            {
                head = new_node;                
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
            
                temp.next = new_node;
            }
        }

        public void Insert(T val, int index)
        {
            if (index >= 0 && index < Count)
            {
                Count++;
                Node new_node = new Node(val);
                Node toBeBumped = head;
                Node connect=head;
                if (index != 0)
                {
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index - 1)
                        {
                            connect = toBeBumped;
                        }
                        toBeBumped = toBeBumped.next;
                    }
                    connect.next = new_node;
                }
                else
                {
                    head = new_node;
                }
                
                new_node.next = toBeBumped;
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }

        }

        public T Get(int index)
        {
            T value = default(T);
            if (index >= 0 && index < Count)
            {
                Node node = head;
                for (int i = 0; i <= index; i++)
                {
                    value = node.data;
                    node = node.next;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
            if (index >= 0 && index < Count)
            {

                Count--;
                Node node = head;
                Node connect = head;
                for (int i = 0; i <= index; i++)
                {
                    value = node.data;
                    if (i == index - 1 && index>0)
                    {
                        connect = node;
                    }
                    node = node.next;
                }
                if (index != 0)
                {
                    connect.next = node;
                }
                else
                {
                    head = node;
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
            T value = head.data;
            if (Count > 1)
            {
                head = head.next;
            }
            else
            {
                head = null;
            }
            Count--;

            return value;
        }

        public T RemoveLast()
        {
            T value = default(T);
            if (Count > 1)
            {               
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                value = temp.data;
                temp = null;
                Count--;
            }
            else
            {
                head = null;
            }
            return value;
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public int Search(T val)
        {
            int index = -1;
            Node node = head;
            int i = 0;
            while (node.next!=null)
            {
                if (node.data.Equals(val))
                {
                    index = i;
                    break;
                }
                node = node.next;
                i++;
            }
            return index;
        }

        public override string ToString()
        {
            string str = "";
            if (Count > 0)
            {
                Node temp = head;
                while (temp.next != null)
                {
                    str += temp.data;
                    temp = temp.next;
                }
                str += temp.data;
            }
            
            return str;
        }
    }
    public class DoubleLinkedList<T>
    {
        Node head;
        public int Count { get; set; } = 0;

        public class Node
        {
            public T data;
            public Node next;
            public Node prev;
            public Node(T d) { data = d; next = null; prev = null; }
        }

        public void Add(T val)
        {
            Count++;
            Node new_node = new Node(val);
            if (head == null)
            {
                new_node.prev = null;
                head = new_node;
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = new_node;
                new_node.prev = temp;
            }
        }

        public void Insert(T val, int index)
        {
            if (index >= 0 && index < Count)
            {
                Count++;
                Node new_node = new Node(val);
                Node toBeBumped = head;
                Node connect = head;
                if (index != 0)
                {
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index - 1)
                        {
                            connect = toBeBumped;
                        }
                        toBeBumped = toBeBumped.next;
                    }
                    connect.next = new_node;
                    new_node.prev = connect;
                }
                else
                {
                    new_node.prev = null;
                    head = new_node;
                }

                new_node.next = toBeBumped;
                toBeBumped.prev = new_node;
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }

        }

        public T Get(int index)
        {
            T value = default(T);
            if (index >= 0 && index < Count)
            {
                Node node = head;
                for (int i = 0; i <= index; i++)
                {
                    value = node.data;
                    node = node.next;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid index");
            }
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
            if (index >= 0 && index < Count)
            {

                Count--;
                Node node = head;
                Node connect = head;
                for (int i = 0; i <= index; i++)
                {
                    value = node.data;
                    if (i == index - 1 && index > 0)
                    {
                        connect = node;
                    }
                    node = node.next;
                }
                if (index != 0)
                {
                    connect.next = node;
                    node.prev = connect;
                }
                else
                {
                    head = node;
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
            T value = head.data;
            if (Count > 1)
            {
                head = head.next;
                head.prev = null;
            }
            else
            {
                head = null;
            }
            Count--;

            return value;
        }

        public T RemoveLast()
        {
            T value = default(T);
            int i = 0;
            if (Count > 1)
            {
                Node temp = head;
                Node beforeLast=head;
                while (temp.next != null)
                {
                    if (i == Count - 1)
                    {
                        beforeLast = temp;
                    }
                    temp = temp.next;
                    i++;
                }
                beforeLast.next = null;
                value = temp.data;
                temp = null;
                Count--;
            }
            else
            {
                head = null;
            }
            return value;
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public int Search(T val)
        {
            int index = -1;
            Node node = head;
            int i = 0;
            while (node.next != null)
            {
                if (node.data.Equals(val))
                {
                    index = i;
                    break;
                }
                node = node.next;
                i++;
            }
            return index;
        }

        public override string ToString()
        {
            string str = "";
            if (Count > 0)
            {
                Node temp = head;
                while (temp.next != null)
                {
                    str += temp.data;
                    temp = temp.next;
                }
                str += temp.data;
            }

            return str;
        }
    }
}
