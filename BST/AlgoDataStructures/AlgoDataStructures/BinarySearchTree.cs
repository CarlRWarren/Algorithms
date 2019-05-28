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
            public int height;
            public int balanceFactor = 0;
            public Node(T d) { data = d; left = null; right = null; height = 1; }


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
            Node newItem = new Node(value);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
            Count++;
        }

        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (Comparer<T>.Default.Compare(n.data , current.data)<0)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (Comparer<T>.Default.Compare(n.data, current.data) > 0)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public override void Remove(T value)
        {
            root = Delete(root, value);
        }
        private Node Delete(Node current, T target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (Comparer<T>.Default.Compare(target , current.data)<0)
                {
                    current.left = Delete(current.left, target);
                    if (balance_factor(current) == -2)//here
                    {
                        if (balance_factor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (Comparer<T>.Default.Compare(target, current.data) > 0)
                {
                    current.right = Delete(current.right, target);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        //delete its inorder successor
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);
                        if (balance_factor(current) == 2)//rebalancing
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                        Count--;
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }
            return current;
        }
       
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        public override int Height()
        {
            return getHeight(root);
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
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
