// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int[] BubbleSort(int[] array)
{
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
        for (int j = 0; j < n - i - 1; j++)
            if (array[j] > array[j + 1])
            {
                // swap temp and arr[i]
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }

    return array;
}
