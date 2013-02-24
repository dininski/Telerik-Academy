using System;
using System.Collections.Generic;

class MergeSort
{

    static int[] merge_sort(int[] arrayToSort)
    {
        if (arrayToSort.Length <= 1)
        {
            return arrayToSort;
        }

        int middle = arrayToSort.Length / 2;
        int[] left = new int[middle];
        int[] right = new int[arrayToSort.Length - middle];
        for (int i = 0; i < middle; i++)
        {
            left[i] = arrayToSort[i];
        }

        for (int j = middle, k = 0; j < arrayToSort.Length; j++, k++)
        {
            right[k] = arrayToSort[j];
        }
        left = merge_sort(left);
        right = merge_sort(right);

        return merge(left, right);
    }

    static int[] merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int leftOffset = 0;
        int rightOffset = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (rightOffset == right.Length)
            {
                result[i] = left[leftOffset];
                leftOffset++;
            }
            else if (leftOffset < left.Length && left[leftOffset] <= right[rightOffset])
            {
                result[i] = left[leftOffset];
                leftOffset++;
            }
            else if (leftOffset == left.Length)
            {
                result[i] = right[rightOffset];
                rightOffset++;
            }
            else if (rightOffset < right.Length && right[rightOffset] <= left[leftOffset])
            {
                result[i] = right[rightOffset];
                rightOffset++;
            }
        }
        return result;
    }

    static void Main()
    {
        int[] toSort = { 3, 543, 654, 34, 43, 5, 454, 325, 432, 543, 543, 5, 4324, 547, 12, 342143, 12, 42 };
        int[] sorted = new int[toSort.Length];

        sorted = merge_sort(toSort);

        foreach (int sortedNum in sorted)
        {
            Console.Write("{0} ", sortedNum);
        }
    }
}
