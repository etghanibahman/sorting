using System;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            Console.WriteLine($"Array is : {String.Join(',', array)}\nSorted Array is : {String.Join(',', QuickSort(array))}");
        }

        public static int[] QuickSort(int[] array)
        {
            QuickSortHelper(array, 0, array.Length - 1);
            return array;
        }

        public static void QuickSortHelper(int[] array, int l, int r)
        {
            if (l > r)
                return;
            Random pivotRandom = new Random();
            int pivotIndex = pivotRandom.Next(l, r + 1);
            Swap(l, pivotIndex, array);
            int j = partition(array, l, r);
            QuickSortHelper(array, l, j - 1);
            QuickSortHelper(array, j + 1, r);
        }

        public static void Swap(int i, int j, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static int partition(int[] array, int l, int r)
        {
            int pivotNumber = array[l];
            int i = l + 1;
            for (int j = l + 1; j <= r; j++)
            {
                if (array[j] < pivotNumber)
                {
                    Swap(i, j, array);
                    i += 1;
                }
            }
            Swap(l, i - 1, array);
            return i - 1;
        }
    }
}
