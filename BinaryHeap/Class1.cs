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
        public BinaryHeap() 
        {
            heap = new List<T>();
        }
        public int heapSize
        {
            get
            {
                return heap.Count();
            }
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
        }
        public T GetMax()
        {
            if (heapSize <= 0)
                throw new IndexOutOfRangeException();
            var result = heap[0];
            heap[0] = heap[heapSize - 1];
            heap.RemoveAt(heapSize - 1);
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
        public void BuildHeap(T [] sourceArray)
        {
            heap = sourceArray.ToList();
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }
        public void HeapSort(T[] array)
        {
            BuildHeap(array);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = GetMax();
            }
        }
    }
}
