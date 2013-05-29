// Write a method that finds the longest subsequence of
// equal numbers in given List<int> and returns the result
// as new List<int>. Write a program to test whether the
// method works correctly.

namespace LongestSubsequenceInList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // using the sample array in order to iniatilize the list
            // in an easy way - just for demostration purposes.
            int[] sampleArray = new int[] { 2, 3, 5, 8, 3, 3, 5, 7, 32, 1, 8, 9, 5, 8, 3, 6, 9, 1 };
            List<int> targetList = sampleArray.ToList();

            targetList.Sort();
            int longestStartIndex = 0;
            int longestSequenceLength = 1;
            int currentLength = 1;
            int currentStartIndex = 0;

            for (int i = 0; i < targetList.Count - 1; i++)
            {
                if (targetList[i] == targetList[i + 1])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > longestSequenceLength)
                    {
                        longestStartIndex = currentStartIndex;
                        longestSequenceLength = currentLength;
                    }

                    currentStartIndex = i + 1;
                    currentLength = 1;
                }
            }

            List<int> longestSequence = targetList.GetRange(longestStartIndex, longestSequenceLength);

            for (int i = 0; i < longestSequence.Count; i++)
            {
                Console.Write("{0} ", longestSequence[i]);
            }

            Console.WriteLine();
        }
    }
}
