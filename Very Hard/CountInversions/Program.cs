using System;
using System.Collections.Generic;
using System.Linq;

namespace CountInversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Test case 1
            //int[] array = new int[] { 2, 3, 3, 1, 9, 5, 6 }; //5

            ////Test case 3
            //int[] array = new int[] { 1, 10, 2, 8, 3, 7, 4, 6, 5 }; //6

            //Test case 3
            int[] array = new int[] { 54, 1, 2, 3, 4 }; //4



            Console.WriteLine($"Array is : {String.Join(',', array)}\nCount of inversions is : {CountInversions(array)}");
        }

        #region O(nlogn)
        public static int CountInversions(int[] array)
        {
            return CountSubArrayInversions(array, 0, array.Length);
        }

        public static int CountSubArrayInversions(int[] array, int start, int end)
        {
            if (end - start < 2) 
                return 0;
            int middle = (int)Math.Floor(decimal.Parse(start.ToString()) + (decimal.Parse(end.ToString()) - start) / 2);

            int leftInversions = CountSubArrayInversions(array,start,middle);
            int rightInversions = CountSubArrayInversions(array,middle + 1,end);
            int mergedArrayInversions = MergeSortAndCountInversions(array,start, middle,end);
            Console.WriteLine($"start:{start}, middle:{middle}, end:{end}");
            Console.WriteLine($"leftInversions:{leftInversions}, rightInversions:{rightInversions}, mergedArrayInversions:{mergedArrayInversions}\ninversions: {leftInversions + rightInversions + mergedArrayInversions}\n");
            return leftInversions + rightInversions + mergedArrayInversions;
        }

        public static int MergeSortAndCountInversions(int[] array, int start, int middle, int end)
        {
            int inversions = 0;
            List<int> sortedArray = new List<int>();
            List<int> lstArray  = array.ToList();
            int left = start;
            int right = middle;

            while (left < middle && right < end)
            {
                if (array[left] <= array[right])
                {
                    sortedArray.Add(array[left]);
                    left++;
                }
                else
                {
                    inversions += (middle - left);
                    sortedArray.Add(array[right]);
                    right++;
                }
            }

            var a1 = left == middle ? new List<int>() : lstArray.GetRange(left, middle - left );
            var a2 = right == end ? new List<int>() : lstArray.GetRange(right + 1, end - right - 1);

            var a3 = a1.Concat(a2).ToList();
            sortedArray = sortedArray.Concat(a3).ToList();

            for (int i = 0; i < sortedArray.Count; i++)
            {
                try
                {
                    array[start + i] = sortedArray[i];
                }
                catch (Exception)
                {
                    Console.WriteLine(i);
                }

            }

            return inversions;
        }


        #endregion

        #region O(n^2)
        //Easy solution, Time complexity = O(n^2)
        //public static int CountInversions(int[] array)
        //{
        //    int inv_count = 0;

        //    for (int i = 0; i < array.Length - 1; i++)
        //        for (int j = i + 1; j < array.Length; j++)
        //            if (array[i] > array[j])
        //                inv_count++;

        //    return inv_count;
        //}
        #endregion

    }

    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            return array.Skip(offset)
                        .Take(length)
                        .ToArray();
        }
    }
}
