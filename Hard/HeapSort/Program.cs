using System;

namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            Console.WriteLine($"Array is : {String.Join(',',array)}\nSorted Array is : {String.Join(',',HeapSort(array))}");
        }

        public static int[] HeapSort(int[] array)
        {
            if (array.Length < 2)
                return array;

            BuildMaxHeap(array);
            var lastUnsortedIndex = array.Length - 1;
            while (lastUnsortedIndex > 0)
            {
                Swap(array, 0, lastUnsortedIndex);
                lastUnsortedIndex--;
                SiftDownTillUnsortedIndex(0, array, lastUnsortedIndex);
            }
            if (array[0] > array[1])
                Swap(array, 0, 1);
            return array;
        }

        private static int[] BuildMaxHeap(int[] array)
        {
            int startIndex = (array.Length / 2) - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                SiftDown(i, array);
            }
            return array;
        }

        private static void SiftDown(int currentIndex, int[] heap)
        {
            //max heap logic
            while (currentIndex < heap.Length)
            {
                var childIndex = 2 * currentIndex + 1;
                var child2Index = 2 * currentIndex + 2;
                var maxChildIndex = -1;
                if (childIndex < heap.Length && child2Index < heap.Length)
                {
                    maxChildIndex = heap[childIndex] > heap[child2Index] ? childIndex : child2Index;
                }
                else if (childIndex < heap.Length)
                {
                    maxChildIndex = childIndex;
                }
                if (maxChildIndex >= 0 && heap[currentIndex] < heap[maxChildIndex])
                {
                    Swap(heap, maxChildIndex, currentIndex);
                    currentIndex = maxChildIndex;
                    continue;
                }
                break;
            }
        }

        private static void SiftDownTillUnsortedIndex(int currentIndex, int[] heap, int lastUnsortedIndex)
        {
            //max heap logic
            while (currentIndex < heap.Length && currentIndex <= lastUnsortedIndex)
            {
                var childIndex = 2 * currentIndex + 1;
                var child2Index = 2 * currentIndex + 2;
                var maxChildIndex = -1;
                if (childIndex < heap.Length && child2Index < heap.Length)
                {
                    maxChildIndex = heap[childIndex] > heap[child2Index] ? childIndex : child2Index;
                }
                else if (childIndex < heap.Length)
                {
                    maxChildIndex = childIndex;
                }
                if (maxChildIndex >= 0 && heap[currentIndex] < heap[maxChildIndex] && maxChildIndex <= lastUnsortedIndex)
                {
                    Swap(heap, maxChildIndex, currentIndex);
                    currentIndex = maxChildIndex;
                    continue;
                }
                break;
            }
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
