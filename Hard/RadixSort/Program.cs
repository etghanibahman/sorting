using System;
using System.Collections.Generic;
using System.Linq;

namespace RadixSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>() { 10, 153, 55, 30, 25, 6, 63 };
            Console.WriteLine($"Array is : {String.Join(',', array)}\nSorted Array is : {String.Join(',', RadixSort(array))}");
        }

        // Time O(d(n + b)))  => d : number of digits,  n => number!:)) , b => mabnaa, base , for example here 10 
        public static List<int> RadixSort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;
            int maxDigits = array.Max().ToString().Length;
            for (int i = 0; i < maxDigits; i++)
            {
                array = array.OrderBy(a => (a / (int)Math.Pow(10,i)) % 10).ToList();
            }
            return array;
        }
    }
}
