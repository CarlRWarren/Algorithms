using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;

namespace LinkedListTester
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void SLL_EmptyList()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            int expectedCount = 0;
            int actualCount = list.Count;
            string expectedString = "";
            string actualString = list.ToString();
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void SLL_Methods()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            //Assert.AreEqual(1, list.Get(0));
            //list.Insert(1, 0);
            //Assert.AreEqual(1, list.Get(0));
            //Assert.AreEqual(1, list.Get(1));
            //var count = list.Count;
            //Assert.AreEqual(2, count);
            //var value = list.Get(0);
            //Assert.AreEqual(1, value);
            //var removed = list.RemoveAt(0);
            //Assert.AreEqual(1, removed);
            //Assert.AreEqual(1, list.Count);
            list.Add(2);
            list.Add(3);

            //var last = list.RemoveLast();
            //Assert.AreEqual(3, last);

            //var first = list.Remove();
            //Assert.AreEqual(1, first);

            //var listString = list.ToString();
            //list.Clear();
            //Assert.AreEqual(0, list.Count);

            var index = list.Search(1);
            Assert.AreEqual(0, index);

        }
    }
}