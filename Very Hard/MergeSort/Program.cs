using System;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            Console.WriteLine($"Array is : {String.Join(',', array)}\nSorted Array is : {String.Join(',', MergeSort(array))}");
        }

        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 0)
                return array;

            MergeHelper(array, 0, array.Length - 1);
            return array;
        }
        public static void MergeHelper(int[] array, int start, int end)
        {
            //Console.WriteLine($"Array is : {String.Join(',', array)}\nstart is : {start}\nend is : {end}\n");
            if (start == end)
                return;

            //divide
            int mid = (end + start) / 2;
            MergeHelper(array, start, mid);
            MergeHelper(array, mid + 1, end);

            //merge 
            int i = start, j = mid + 1;
            int index = 0;
            int[] aux = new int[end - start + 1];

            while (i <= mid && j <= end) 
                if (array[i] < array[j])
                    aux[index++] = array[i++];
                else
                    aux[index++] = array[j++];
            

            while (i <= mid) 
                aux[index++] = array[i++];
            
            while (j <= end)
                aux[index++] = array[j++];

            index = 0;

            Console.WriteLine($"Aux Array is : {String.Join(',', aux)}\nstart is : {start}\nend is : {end}\n");
            for (int k = start; k <= end; k++)
            {
                array[k] = aux[index++];
            }
        }

    }
}
