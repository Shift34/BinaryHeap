using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> heap;
        public int heapSize { get; private set; }
        public BinaryHeap() 
        {
            heap = new List<T>();
        }

        public void Add(T item) 
        {
            heap.Add(item);
            if (heapSize == 1) 
                return;     

           
            int current = heapSize - 1;        
            int parent = (current - 1) / 2; 

            while (heap[parent].CompareTo(heap[current]) < 0)
            {
                T temp = heap[current];
                heap[current] = heap[parent];
                heap[parent] = temp;

                current = parent;
                parent = (current - 1) / 2;
            }
            heapSize++;
        }
        public T GetMax()
        {
            if (heapSize <= 0)
                throw new IndexOutOfRangeException();
            var result = heap[0];
            heap[0] = heap[heapSize - 1];
            heap.RemoveAt(heapSize - 1);
            heapSize--;
            Heapify(0);
            return result;
        }
        public T FindMax()
        {
            return heap[0];
        }
        private void Heapify(int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var largest = index;
            if (left < heapSize && heap[left].CompareTo(heap[index]) > 0)
                largest = left;
            if (right < heapSize && heap[right].CompareTo(heap[largest]) > 0)
                largest = right;
            if (largest == index) return;
            var temp = heap[largest];
            heap[largest] = heap[index];
            heap[index] = temp;
            Heapify(largest);
        }
        public void BuildHeap(T [] sourceheapay)
        {
            heap = sourceheapay.ToList();
            heapSize = heap.Count;
            for (int i = (heapSize - 1) / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }
        public void HeapSortRecursion(ref T[] heapay)
        {
            BuildHeap(heapay);
            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(0, i);
                heapSize--;
                Heapify(0);
            }
            heapay = heap.ToArray();
        }
        public void HeapSortNoRecursion(ref T[] heapay)
        {
            BuildHeap(heapay);
            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(0, i);
                heapSize--;
                Sort(0);
            }
            heapay = heap.ToArray();
        }
        private void Sort(int curentIndex)
        {
            int maxIndex = curentIndex;
            int leftIndex;
            int rightIndex;

            while (curentIndex < heapSize)
            {
                leftIndex = 2 * curentIndex + 1;
                rightIndex = 2 * curentIndex + 2;

                if (leftIndex < heapSize && heap[leftIndex].CompareTo(heap[maxIndex]) > 0)
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < heapSize && heap[rightIndex].CompareTo(heap[maxIndex]) > 0)
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == curentIndex)
                {
                    break;
                }

                Swap(curentIndex, maxIndex);
                curentIndex = maxIndex;
            }
        }
        private void Swap(int positionA, int positionB)
        {
            if (positionA < heapSize && positionB < heapSize)
            {
                var temp = heap[positionA];
                heap[positionA] = heap[positionB];
                heap[positionB] = temp;
            }
        }
    }
}
