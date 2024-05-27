using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BinaryHeap;

namespace BinaryHeapConsole
{
    internal class BinaryHeapConsole
    {
        static void Main(string[] args)
        {
            int n = 10000;
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
            array.CopyTo(array1,0);

            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            binaryHeap.HeapSortNoRecursion(ref array1);
            stopWatch.Stop();
            Console.WriteLine("HeapSortNoRecursion random with all the different elements: {0}", stopWatch.ElapsedMilliseconds);
            //foreach (int i in array1)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();

            Stopwatch Watch = new Stopwatch();
            BinaryHeap<int> binaryHeap1 = new BinaryHeap<int>();
            Watch.Start();
            binaryHeap1.HeapSortRecursion(ref array);
            Watch.Stop();
            Console.WriteLine("HeapSortRecursion random with all the different elements: {0}", Watch.ElapsedMilliseconds);
            //foreach (int i in array)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();


            int[] array2 = new int[n];

            Random randNum1 = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randInt = randNum1.Next(0, 3 * n);
                array2[i] = randInt;
            }
            int[] array3 = new int[n];
            array2.CopyTo(array3, 0);


            stopWatch.Restart();
            binaryHeap.HeapSortNoRecursion(ref array2);
            stopWatch.Stop();
            Console.WriteLine("HeapSortNoRecursion random with repeating elements: {0}", stopWatch.ElapsedMilliseconds);
            //foreach (int i in array2)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();


            Watch.Restart();
            binaryHeap1.HeapSortRecursion(ref array3);
            Watch.Stop();
            Console.WriteLine("HeapSortRecursion random with repeating elements: {0}", Watch.ElapsedMilliseconds);
            //foreach (int i in array3)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();

            int[] array4 = new int[n];

            Random randNum2 = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randInt = randNum2.Next(0, 3 * n);
                array4[i] = randInt;
            }
            int[] array5 = new int[n];
            array4.CopyTo(array5, 0);


            Array.Sort(array4);
            stopWatch.Restart();
            binaryHeap.HeapSortNoRecursion(ref array4);
            stopWatch.Stop();
            Console.WriteLine("HeapSortNoRecursion Sorted: {0}", stopWatch.ElapsedMilliseconds);
            //foreach (int i in array4)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();

            Array.Sort(array5);
            Watch.Restart();
            binaryHeap1.HeapSortRecursion(ref array5);
            Watch.Stop();
            Console.WriteLine("HeapSortRecursion Sorted: {0}", Watch.ElapsedMilliseconds);
            //foreach (int i in array5)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();

            int[] array6 = new int[n];

            Random randNum3 = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randInt = randNum3.Next(0, 3 * n);
                array6[i] = randInt;
            }
            int[] array7 = new int[n];
            array6.CopyTo(array7, 0);

            BinaryHeap<int> binaryHeap2 = new BinaryHeap<int>();
            for(int i = 0; i < array6.Length; i++)
            {
                binaryHeap2.Add(array6[i]);
            }
            stopWatch.Restart();
            array6 = binaryHeap2.HeapSortNoRecursion();
            stopWatch.Stop();
            Console.WriteLine("HeapSortNoRecursion partially sorted: {0}", stopWatch.ElapsedMilliseconds);
            //foreach (int i in array6)
            //{
            //    Console.Write(i + " ");
            //}

            Console.WriteLine();

            BinaryHeap<int> binaryHeap3 = new BinaryHeap<int>();
            for (int i = 0; i < array7.Length; i++)
            {
                binaryHeap3.Add(array7[i]);
            }
            Watch.Restart();
            array7 = binaryHeap3.HeapSortRecursion();
            Watch.Stop();
            Console.WriteLine("HeapSortRecursion partially sorted: {0}", Watch.ElapsedMilliseconds);
            //foreach (int i in array7)
            //{
            //    Console.Write(i + " ");
            //}


            Console.ReadKey();
        }
    }
}
