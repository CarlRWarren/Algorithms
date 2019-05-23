using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class BinaryTree<T>
    {
        public Node root=null;
        public virtual int Count { get; set; } = 0;
        public static string inOrder = "";
        public static string preOrder = "";
        public static string postOrder = "";
        public static string bfs = "";

        public class Node
        {
            public T data;
            public Node left;
            public Node right;
            public int balanceFactor = 0;
            public Node(T d) { data = d; left = null; right = null; }


            internal bool Find(T value)
            {
                if (data.Equals(value)) return true;
                else
                {
                    if(Comparer<T>.Default.Compare(value, data) < 0)
                    {
                        return left.Find(value);
                    }
                    else
                    {
                        return right.Find(value);
                    }
                }
            }

            internal bool Delete(T key, Node node, Node parent)
            {
                if (node == null) return false;

                if (Comparer<T>.Default.Compare(key, node.data) < 0) return node.left.Delete(key, node.left, node);
                else if (Comparer<T>.Default.Compare(key, node.data) > 0) return node.right.Delete(key, node.right, node);
                else
                {
                    if (node == parent)
                    {
                        Node replacement = FindReplacement(node.left);
                        replacement.Delete(replacement.data, replacement, node);
                        replacement.left = node.left;
                        replacement.right = node.right;
                        return true;
                    }
                    else if (node.left == null && node.right == null)
                    {
                        if (parent.left == node) parent.left = null;
                        else parent.right = null;
                        return true;
                    }
                    else if (node.left == null && node.right != null)
                    {
                        if (parent.left == node) parent.left = node.right;
                        else parent.right = node.right;
                        return true;
                    }
                    else if (node.left != null && node.right == null)
                    {
                        if (parent.left == node) parent.left = node.left;
                        else parent.right = node.left;
                        return true;
                    }
                    else
                    {
                        Node replacement=FindReplacement(node);
                        if (replacement == node)
                        {
                            node = null;
                            return true;
                        }
                        replacement.Delete(replacement.data, replacement, replacement);
                        if (parent.left == node) parent.left = replacement;
                        else parent.right = replacement;
                        replacement.left = node.left;
                        replacement.right = node.right;
                        return true;
                    }
                    
                }
            }

            internal Node FindReplacement(Node replacement)
            {
                while (replacement.right != null)
                {
                    replacement = replacement.right;
                }
               
                return replacement;
            }

            internal T MinValue(Node r)
            {
                T minv = r.data;
                while (r.left != null)
                {
                    minv = r.left.data;
                    r = r.left;
                }
                return minv;
            }

            internal void Add(T value)
            {
                Node new_node = new Node(value);
                if (Comparer<T>.Default.Compare(value, data) < 0)
                {
                    if (left == null)
                    {
                        left = new_node;
                    }
                    else
                    {
                        left.Add(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new_node;
                    }
                    else
                    {
                        right.Add(value);
                    }
                }
            }

            internal void InOrder(Node node)
            {
                if (node != null)
                {
                    node.InOrder(node.left);
                    inOrder+=node.data.ToString()+", ";
                    node.InOrder(node.right);
                }
            }

            internal void PreOrder(Node node)
            {
                if (node != null)
                {
                    preOrder += node.data.ToString() + ", ";
                    node.PreOrder(node.left);
                    node.PreOrder(node.right);
                }
            }

            internal void PostOrder(Node node)
            {
                if (node != null)
                {
                    node.PostOrder(node.left);
                    postOrder += node.data.ToString() + ", ";
                    node.PostOrder(node.right);
                }
            }

            internal int maxDepth(Node node)
            {
                if (node == null)
                    return 0;
                else
                {
                    /* compute the depth of each subtree */
                    int lDepth = maxDepth(node.left);
                    int rDepth = maxDepth(node.right);

                    /* use the larger one */
                    if (lDepth > rDepth)
                        return (lDepth + 1);
                    else
                        return (rDepth + 1);
                }
            }

            internal void Balance(Node node, int balance)
            {
                if (balance == 2) //right outweighs
                {
                    int rightBalance = node.right!=null? BalanceFactor(node.right):0;
                    if (rightBalance == 1 || rightBalance == 0)
                    {
                        node = RotateLL(node);
                    }
                    else if (rightBalance == -1)
                    {
                        node = RotateRL(node.right);
                        
                    }
                }
                else if (balance == -2) //left outweighs
                {
                    int leftBalance = BalanceFactor(node.left);
                    if (leftBalance == 1)
                    {
                        node = RotateLR(node.left);
                        
                    }
                    else if (leftBalance == -1 || leftBalance == 0)
                    {
                        node = RotateRR(node);
                    }
                }
            }

            private Node RotateRR(Node parent)
            {
                Node pivot = parent.right;
                parent.right = pivot.left;
                pivot.left = parent;
                return pivot;
            }
            private Node RotateLL(Node parent)
            {
                Node pivot = parent.left;
                parent.left = pivot.right;
                pivot.right = parent;
                return pivot;
            }
            private Node RotateLR(Node parent)
            {
                Node pivot = parent.left;
                parent.left = RotateRR(pivot);
                return RotateLL(parent);
            }
            private Node RotateRL(Node parent)
            {
                Node pivot = parent.right;
                parent.right = RotateLL(pivot);
                return RotateRR(parent);
            }

            internal int BalanceFactor(Node current)
            {
                return current.maxDepth(current.left) - current.maxDepth(current.right);
            }
        }

        public virtual void Add(T value)
        {
            Node new_node = new Node(value);
            //Node parent;
            Count++;
            if (root == null)
            {
                root = new_node;
            }
            else
            {
                root.Add(value);
            }
        }

        public virtual bool Contains(T value)
        {
            if (root==null) return false;
            return root.Find(value);
        }
        

        public virtual void Remove(T value)
        {
            if (root.Delete(value, root, root)) Count--;
        }

        public virtual void Clear()
        {
            root = null;
            Count = 0;
        }

        public virtual string InOrder()
        {
            inOrder = "";
            root.InOrder(root);
            inOrder = inOrder.Trim();
            inOrder = inOrder.Remove(inOrder.LastIndexOf(','));
            return inOrder;
        }

        public virtual string PreOrder()
        {
            root.PreOrder(root);
            preOrder = preOrder.Trim();
            preOrder = preOrder.Remove(preOrder.LastIndexOf(','));
            return preOrder;
        }

        public virtual string PostOrder()
        {
            root.PostOrder(root.left);
            root.PostOrder(root.right);
            postOrder += root.data.ToString() + ", ";
            postOrder = postOrder.Trim();
            postOrder = postOrder.Remove(postOrder.LastIndexOf(','));
            return postOrder;
        }

        public virtual int Height()
        {
            int h = root.maxDepth(root);
            return h;
        }

        public virtual T[] ToArray()
        {
            inOrder = "";
            InOrder();
            string[] vals = inOrder.Split(new char[] { ',' });
            List<T> values = new List<T>();
            foreach(var item in vals)
            {
                values.Add((T)Convert.ChangeType(item.Trim(), typeof(T)));
            }
            T[] actuals = values.ToArray();
            return actuals;
        }
    }

    public class AVLTree<T>:BinaryTree<T>
    {
        public override void Add(T value)
        {
            base.Add(value);
            int balance = root.BalanceFactor(root);
            if (balance == Math.Abs(2))
            {
                root.Balance(root, balance);
            }
        }

        public override void Remove(T value)
        {
            base.Remove(value);
            int balance = root.BalanceFactor(root);
            if (balance == Math.Abs(2))
            {
                root.Balance(root, balance);
            }
        }

        public override T[] ToArray()
        {
            bfs = "";
            BFS();
            string[] vals = bfs.Split(new char[] { ',' });
            List<T> values = new List<T>();
            foreach (var item in vals)
            {
                values.Add((T)Convert.ChangeType(item.Trim(), typeof(T)));
            }
            T[] actuals = values.ToArray();
            return actuals;
        }

        public string BFS()
        {
            bfs = "";
            Breadth(root);
            bfs = bfs.Trim();
            bfs = bfs.Remove(bfs.LastIndexOf(','));
            return bfs;
        }
        Queue<Node> queue = new Queue<Node>();
        public void Breadth(Node node)
        {
            if (node == null)
                return;
            queue.Clear();
            queue.Enqueue(node);
            while (!(queue.Count==0))
            {
                Node nextNode = queue.Dequeue();
                bfs+=nextNode.data+ ", ";
                if (nextNode.left != null) queue.Enqueue(nextNode.left);
                if (nextNode.right != null) queue.Enqueue(nextNode.right);
            }

        }
    }
}
