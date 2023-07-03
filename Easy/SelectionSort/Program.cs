// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



int[] SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int indexOfMin = i;
        int minValue = array[i];
        for (int j = i; j < array.Length; j++)
        {
            if (array[j] < minValue)
            {
                indexOfMin = j;
                minValue = array[j];
            }
        }

        int temp = array[i];
        array[i] = array[indexOfMin];
        array[indexOfMin] = temp;
    }
    return array;
}

////With linq
//int[] SelectionSort(int[] array)
//{
//    for (int i = 0; i < array.Length; i++)
//    {
//        int min = array.Skip(i).Min();
//        int indexOfMin = Array.IndexOf(array.Skip(i).ToArray(), min) + i;

//        int temp = array[i];
//        array[i] = min;
//        array[indexOfMin] = temp;
//    }
//    return array;
//}
