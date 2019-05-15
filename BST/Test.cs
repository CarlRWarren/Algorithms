using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchTree;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void Count()
        {
            int testCount = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            for(int i = 0; i < testCount; i++)
            {
                tree.Add(i);
            }
            Assert.AreEqual(testCount, tree.Count);
        }

        [TestMethod]
        public void Add()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(0);
            tree.Add(2);
            tree.Add(1);
            tree.Add(2);
            Assert.AreEqual(4, tree.Count);
        }

        [TestMethod]
        public void Contains()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(0);
            tree.Add(1);
            Assert.AreEqual(true, tree.Contains(1));
        }

        [TestMethod]
        public void Remove()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(1);
            tree.Add(4);
            tree.Add(2);
            tree.Remove(1);
            Assert.AreEqual(5, tree.Count);
            tree.Remove(3);
            Assert.AreEqual(4, tree.Count);
        }

        [TestMethod]
        public void Clear()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(0);
            tree.Add(2);
            tree.Add(1);
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void InOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(2);
            Assert.AreEqual("1, 2, 2, 4, 5", tree.InOrder());
        }

        [TestMethod]
        public void PreOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(2);
            Assert.AreEqual("4, 2, 1, 2, 5", tree.PreOrder());
        }

        [TestMethod]
        public void PostOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(2);
            Assert.AreEqual("1, 2, 2, 5, 4", tree.PostOrder());
        }

        [TestMethod]
        public void Height()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(2);
            Assert.AreEqual(3, tree.Height());
            tree.Remove(1);
            tree.Remove(2);
            Assert.AreEqual(2, tree.Height());

        }

        [TestMethod]
        public void ToArray()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(5);
            tree.Add(2);
            int[] testArray = new int[] { 1, 2, 2, 4, 5 };
            Assert.AreEqual(testArray.ToString(), tree.ToArray().ToString());
        }
    }
}
