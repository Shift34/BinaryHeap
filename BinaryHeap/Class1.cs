using System;
using System.Collections;
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
        private T[] heap { get; set; }
        public int heapSize { get; private set; }
        private int Capacity { get; set; }
        public BinaryHeap() : this(7)
        { }
        public BinaryHeap(IComparer<T> customComparer) : this(4, new T[4], 0)
        { }
        public BinaryHeap(int Capacity) : this(Capacity, new T[Capacity], 0)
        { }
        public BinaryHeap(T[] source) : this((source.Count() * 2), source, source.Count())
        { }
        private BinaryHeap(int сapacity, T[] source, int count)
        {
            this.Capacity = сapacity;
            heap = source;
            heapSize = count;

            if (heapSize != 0)
            {
                BuildHeap(heap);
            }
        }

        private void IncreaseCapacity()
        {
            Capacity *= 2;
            var temp = new T[Capacity];
            Array.Copy(heap, temp, heapSize);
            heap = temp;
        }

        public void Remove(T value)
        {
            var index = Array.IndexOf(heap, value);

            if (index == -1)
            {
                throw new ArgumentException($"{value} not in heap!");
            }

            (heap[index], heap[heapSize - 1]) = (heap[heapSize - 1], heap[index]);

            if (index < heapSize)
            {
                if (heap[--heapSize].CompareTo(heap[index]) > 0)
                {
                    HeapifyUp(heapSize);
                }
            }
        }
        public void Add(T item)
        {
            if (heapSize == Capacity)
            {
                IncreaseCapacity();
            }
            heapSize++;
            heap[heapSize - 1] = item;
            if (heapSize == 1)
                return;
            HeapifyUp(heapSize);
        }
        public T GetMax()
        {
            if (heapSize <= 0)
                throw new IndexOutOfRangeException();
            var result = heap[0];
            heap[0] = heap[--heapSize];
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
        private void BuildHeap(T [] sourceheapay)
        {
            heap = sourceheapay.ToArray();
            heapSize = heap.Count();
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
        public T[] HeapSortRecursion()
        {
            int n = heapSize;
            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(0, i);
                heapSize--;
                Heapify(0);
            }
            T[] heapify = new T[n]; ;
            Array.Copy(heap, heapify, n);
            return heapify;
        }
        public T[] HeapSortNoRecursion()
        {
            int n = heapSize;
            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(0, i);
                heapSize--;
                Sort(0);
            }
            T[] heapify = new T[n]; ;
            Array.Copy(heap, heapify, n);
            return heapify;
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
        private void HeapifyUp(int index)
        {
            int i = index - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && heap[parent].CompareTo(heap[i]) < 0)
            {
                Swap(i, parent);

                i = parent;
                parent = (i - 1) / 2;
            }
        }
    }
}
