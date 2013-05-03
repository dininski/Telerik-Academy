namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array cannot be null!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            // check if the array has been properly sorted
            for (int i = 1; i < arr.Length - 1; i++)
            {
                Debug.Assert(arr[i - 1].CompareTo(arr[i]) <= 0, "The array is not properly sorted!");
            }
        }

        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            // Check if the array has been sorted
            for (int i = 1; i < arr.Length - 1; i++)
            {
                Debug.Assert(arr[i - 1].CompareTo(arr[i]) <= 0, "The array is not correctly sorted!");
            }

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            // Check if the arguments are valid
            Debug.Assert(arr != null, "The array cannot be null!");
            Debug.Assert(startIndex >= 0, "The start index cannot be negative!");
            Debug.Assert(startIndex < endIndex, "The ending index cannot be before the starting index!");
            Debug.Assert(endIndex <= arr.Length - 1, "The ending index cannot be bigger than the lenght of the array!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            // Check if the smallest element was correctly found using lambda expression
            Debug.Assert(
                arr[minElementIndex].CompareTo(arr.Skip(startIndex).Take(endIndex - startIndex + 1).Min()) == 0,
                "The smallest element was incorrectly found");

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "The first argument cannot be null!");
            Debug.Assert(y != null, "The second argument cannot be null!");
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}