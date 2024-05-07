using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BinaryHeap;

namespace BinaryHeapConsole
{
    internal class BinaryHeapConsole
    {
        static void Main(string[] args)
        {
            int n = 10;
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
            Console.WriteLine("HeapSortNoRecursion: {0}", stopWatch.ElapsedMilliseconds);
            foreach (int i in array1)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            Stopwatch Watch = new Stopwatch();
            BinaryHeap<int> binaryHeap1 = new BinaryHeap<int>();
            Watch.Start();
            binaryHeap1.HeapSortRecursion(ref array);
            Watch.Stop();
            Console.WriteLine("HeapSortRecursion: {0}", Watch.ElapsedMilliseconds);
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}
