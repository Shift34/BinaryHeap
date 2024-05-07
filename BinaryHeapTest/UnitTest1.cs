using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BinaryHeap;
using System.Linq;
using System.Collections.Generic;

namespace BinaryHeapTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindTest()
        {
            var heap = new BinaryHeap<int>();
            int n = 10;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                heap.Add(i);
                array[i] = i;
            }
            var value = heap.FindMax();
            Assert.AreEqual(array.Max(), value);
        }
        [TestMethod]
        public void FindMaxAllElement()
        {
            var heap = new BinaryHeap<int>();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                heap.Add(i);
            }
            for (int i = 9; i <= 0; i--)
            {
                if (i != heap.GetMax())
                {
                    throw new ArgumentException();
                }
            }
        }
        [TestMethod]
        public void HeapSizeTest()
        {
            var heap = new BinaryHeap<int>();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(i, heap.heapSize);
                heap.Add(i);
            }
        }
        [TestMethod]
        public void Remove()
        {
            var heap = new BinaryHeap<int>();
            List<int> list = new List<int>();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                heap.Add(i);
                list.Add(i);
            }
            heap.Remove(4);
            heap.Remove(5);
            list.Remove(4);
            list.Remove(5);
            list.Sort();
            list.Reverse();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != heap.GetMax())
                {
                    throw new ArgumentException();
                }
            }
        }
        [TestMethod]
        public void HeapSortNoRecursion()
        {
            int n = 100;
            int[] array = new int[n];

            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                bool flag = true;
                while (flag)
                {
                    int randInt = randNum.Next(0, 3 * n);
                    if (!array.Contains(randInt))
                    {
                        array[i] = randInt;
                        flag = false;
                    }
                }
            }
            int[] array1 = new int[n];
            array.CopyTo(array1, 0);
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.HeapSortNoRecursion(ref array1);
            Array.Sort(array);
            Assert.AreEqual(array.Count(), array1.Count());
            for ( int i = 0; i < array1.Length; i++)
            {
                if (array[i] != array1[i])
                {
                    throw new ArgumentException();
                }
            }
        }
        [TestMethod]
        public void HeapSortRecursion()
        {
            int n = 100;
            int[] array = new int[n];

            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                bool flag = true;
                while (flag)
                {
                    int randInt = randNum.Next(0, 3 * n);
                    if (!array.Contains(randInt))
                    {
                        array[i] = randInt;
                        flag = false;
                    }
                }
            }
            int[] array1 = new int[n];
            array.CopyTo(array1, 0);
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.HeapSortRecursion(ref array1);
            Array.Sort(array);
            Assert.AreEqual(array.Count(), array1.Count());
            for (int i = 0; i < array1.Length; i++)
            {
                if (array[i] != array1[i])
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
