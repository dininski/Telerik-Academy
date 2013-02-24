using System;

class QuickSort
{
    public static int partition(int[] arr, int left, int right)
    {
        int i = left;
        int j = right;
        int tmp;
        int pivot = arr[(left+right)/2];
        while (i <= j)
        {
            while (arr[i] < pivot)
            {
                i++;
            }
            while (arr[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }
        }
        return i;
    }

    public static void quickSort(int[] arr, int left, int right)
    {
        int index = partition(arr, left, right);
        if (left < index - 1)
        {
            quickSort(arr, left, index - 1);
        }
        if (index < right)
        {
            quickSort(arr, index, right);
        }
    }

    static void Main()
    {
        int[] toSort = { 156, 3189, 79, 13, 18, 94, 9, 1, 3, 89489, 79, 1, 61, 892, 81, 36, 13, 89, 859, 8 };
        quickSort(toSort, 0, toSort.Length - 1);

        foreach (int a in toSort)
        {
            Console.WriteLine(a);
        }
    }
}