using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void Count()
        {
            int testCount = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            for (int i = 0; i < testCount; i++)
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
    namespace AVLUnitTester
    {
        [TestClass]
        public class AVLUnitTests
        {
            [TestMethod]
            public void AddOneValueToEmptyTree()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(10);

                string expected = "10";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddThreeValuesToTree()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);

                string expected = "24, 10, 1337";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddThreeValuesSingleRightRotation()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(1337);
                avl.Add(24);
                avl.Add(10);

                string expected = "24, 10, 1337";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddThreeValuesSingleLeftRotation()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(10);
                avl.Add(24);
                avl.Add(1337);

                string expected = "24, 10, 1337";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddThreeValuesDoubleLeftRightRotation()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(1337);
                avl.Add(10);
                avl.Add(24);

                string expected = "24, 10, 1337";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddThreeValuesDoubleRightLeftRotation()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(10);
                avl.Add(1337);
                avl.Add(24);

                string expected = "24, 10, 1337";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddManyValuesNoRotations()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                string expected = "24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddManyValuesInDescendingOrder()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(1500);
                avl.Add(1400);
                avl.Add(1350);
                avl.Add(1337);
                avl.Add(110);
                avl.Add(100);
                avl.Add(90);
                avl.Add(24);
                avl.Add(13);
                avl.Add(12);
                avl.Add(11);
                avl.Add(10);
                avl.Add(9);
                avl.Add(8);
                avl.Add(7);

                string expected = "24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddManyValuesInAscendingOrder()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(7);
                avl.Add(8);
                avl.Add(9);
                avl.Add(10);
                avl.Add(11);
                avl.Add(12);
                avl.Add(13);
                avl.Add(24);
                avl.Add(90);
                avl.Add(100);
                avl.Add(110);
                avl.Add(1337);
                avl.Add(1350);
                avl.Add(1400);
                avl.Add(1500);

                string expected = "24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddManyValuesWithDoubleRotations()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(100);
                avl.Add(90);
                avl.Add(7);
                avl.Add(8);
                avl.Add(9);
                avl.Add(12);
                avl.Add(13);
                avl.Add(10);
                avl.Add(11);
                avl.Add(110);
                avl.Add(1400);
                avl.Add(1337);
                avl.Add(1350);
                avl.Add(1500);

                string expected = "12, 9, 100, 8, 10, 24, 1337, 7, 11, 13, 90, 110, 1400, 1350, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveLeftLeaf()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);

                avl.Remove(10);

                string expected = "24, 1337";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveRightLeaf()
            {
                AVLTree<int> avl = new AVLTree<int>();

                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);

                avl.Remove(1337);

                string expected = "24, 10";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveRoot()
            {
                AVLTree<int> avl = new AVLTree<int>();

                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);

                avl.Remove(24);

                string expected = "1337, 10";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveLeftBranchRoot()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                avl.Remove(10);

                string expected = "24, 11, 1337, 8, 12, 100, 1400, 7, 9, 13, 90, 110, 1350, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveRightBranchRoot()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                avl.Remove(1337);

                string expected = "24, 10, 1350, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveRootFromLargeTree()
            {
                AVLTree<int> avl = new AVLTree<int>();
                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                avl.Remove(24);

                string expected = "90, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 110, 1350, 1500";
                string actual = ArrayToString(avl.ToArray());

                Assert.AreEqual(expected, actual);
            }



            [TestMethod]
            public void CountIsCorrectAfterAdd()
            {
                AVLTree<int> avl = new AVLTree<int>();
                int expected = 15;

                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                Assert.AreEqual(expected, avl.Count);
            }

            [TestMethod]
            public void CountIsCorrectAfterRemove()
            {
                AVLTree<int> avl = new AVLTree<int>();
                int expected = 14;

                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                avl.Remove(10);

                Assert.AreEqual(expected, avl.Count);
            }

            [TestMethod]
            public void CountIsCorrectAfterAddRemoveAdd()
            {
                AVLTree<int> avl = new AVLTree<int>();
                int expected = 13;

                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                avl.Remove(10);
                avl.Remove(1337);
                avl.Remove(24);

                avl.Add(1842);

                Assert.AreEqual(expected, avl.Count);
            }

            [TestMethod]
            public void ToArraySequenceIsCorrect()
            {
                AVLTree<int> avl = new AVLTree<int>();
                int[] expectedArr = { 24, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1350, 1500 };

                avl.Add(24);
                avl.Add(10);
                avl.Add(1337);
                avl.Add(8);
                avl.Add(12);
                avl.Add(100);
                avl.Add(1400);
                avl.Add(7);
                avl.Add(9);
                avl.Add(11);
                avl.Add(13);
                avl.Add(90);
                avl.Add(110);
                avl.Add(1350);
                avl.Add(1500);

                string expected = ArrayToString(expectedArr);
                string actual = ArrayToString(avl.ToArray());
                Assert.AreEqual(expected, actual);
            }

            private string ArrayToString(int[] a)
            {
                StringBuilder sb = new StringBuilder();

                if (a.Length > 0)
                {
                    sb.Append(a[0]);
                    for (int i = 1; i < a.Length; i++)
                    {
                        sb.Append(", ");
                        sb.Append(a[i]);
                    }

                }

                return sb.ToString();
            }
        }
    }
}
