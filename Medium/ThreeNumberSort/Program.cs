// See https://aka.ms/new-console-template for more information
int[] array = new int[] { 1, 0, 0, -1, -1, 0, 1, 1 };
int[] order = new int[] { 0, 1, -1 };
Console.WriteLine($"array: {String.Join(',',array)} , order: {String.Join(',',order)}");
Console.WriteLine($"ordered array: {String.Join(',', ThreeNumberSort(array,order))}");


//O(n) Time | O(1) Space
int[] ThreeNumberSort(int[] array, int[] order)
{
    int start = 0;

    for (int index = 0; index < order.Length; index++) {
        int end = array.Length - 1;
        while (start <= end)
        {
            if (array[start] == order[index])
            {
                start++;
                continue;
            }
            if (array[end] == order[index]) { 
                int temp = array[end];
                array[end] = array[start];
                array[start] = temp;
                start++;
            }
            end--;
        }
    }
    return array;
}