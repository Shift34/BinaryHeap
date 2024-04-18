using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryHeap;

namespace BinaryHeapConsole
{
    internal class BinaryHeapConsole
    {
        static void Main(string[] args)
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Add(1);
            binaryHeap.Add(2);
            binaryHeap.Add(8);
            binaryHeap.Add(4);

            binaryHeap.GetMax();
            Console.ReadKey();
        }
    }
}
