using AlgoDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTester
{
    [TestClass]
    public class AVLTester
    {
        [TestMethod]
        public void Right()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(3);
            tree.Add(2);
            Assert.AreEqual("2, 3", tree.InOrder());
            tree.Add(1);
            Assert.AreEqual("1, 2, 3", tree.InOrder());
            Assert.AreEqual(2, tree.Height());
        }

        [TestMethod]
        public void Left()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            Assert.AreEqual("1, 2", tree.InOrder());
            tree.Add(3);
            Assert.AreEqual("1, 2, 3", tree.InOrder());
            Assert.AreEqual(2, tree.Height());
        }

        [TestMethod]
        public void RightLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(3);
            Assert.AreEqual("1, 3", tree.InOrder());
            tree.Add(2);
            Assert.AreEqual("1, 2, 3", tree.InOrder());
            Assert.AreEqual(2, tree.Height());
        }

        [TestMethod]
        public void LeftRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(3);
            tree.Add(1);
            Assert.AreEqual("1, 3", tree.InOrder());
            tree.Add(2);
            Assert.AreEqual("1, 2, 3", tree.InOrder());
            Assert.AreEqual(2, tree.Height());
        }

        [TestMethod]
        public void Complex()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(50);
            tree.Add(40);
            tree.Add(60);
            tree.Add(58);
            tree.Add(30);
            tree.Add(45);
            tree.Add(70);
            tree.Add(80);
            tree.Add(75);
            tree.Add(78);
            Assert.AreEqual(4, tree.Height());
            Assert.AreEqual("30, 40, 45, 50, 58, 60, 70, 75, 78, 80", tree.InOrder());
            Assert.AreEqual(10, tree.Count);
        }

        [TestMethod]
        public void Removal()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(50);
            tree.Add(40);
            tree.Add(60);
            tree.Add(70);
            tree.Remove(40);
            Assert.AreEqual(2, tree.Height());
            Assert.AreEqual("50, 60, 70", tree.InOrder());
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void ToArrayAVL()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(11);
            tree.Add(10);
            tree.Add(24);
            tree.Add(13);
            tree.Add(56);
            int[] testArray = new int[] { 11, 10, 24, 13, 56 };
            CollectionAssert.AreEqual(testArray, tree.ToArray());
        }
    }
}
