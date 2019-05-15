using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class BinarySearchTree<T>
    {
        Node root=null;
        public int Count { get; set; } = 0;

        public class Node
        {
            public T data;
            public Node left;
            public Node right;
            public Node(T d) { data = d; left = null; right = null; }
        }

        public void Add(T value)
        {
            Node new_node = new Node(value);
            Node current;
            //Node parent;
            Count++;
            if (root == null)
            {
                root = new_node;
            }
            else
            {
                current = root;
                Comparer<T> comparer = default(Comparer<T>);
                bool nulled = false;
                while (!nulled)
                {
                    if (current == null)
                    {
                        current = new_node;
                        nulled = true;
                        break;
                    }
                    if (comparer.Compare(value, current.data) < 0)
                    {
                        if (current.left != null)
                        {
                            current = current.left;
                        }
                        
                    }
                    else
                    {
                        if (current.right != null)
                        {
                            current = current.right;
                        }
                    }
                }                         
            }
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string InOrder()
        {
            throw new NotImplementedException();
        }

        public string PreOrder()
        {
            throw new NotImplementedException();
        }

        public string PostOrder()
        {
            throw new NotImplementedException();
        }

        public T Height()
        {
            throw new NotImplementedException();
        }

        public object ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
