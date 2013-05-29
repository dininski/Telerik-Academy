// The majorant of an array of size N is a value that occurs
// in it at least N/2 + 1 times. Write a program to find the
// majorant of given array (if exists). Example:
// {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3


namespace Majorant
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int[] sampleValues = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Stack<int> occurences = new Stack<int>();
            
            occurences.Push(sampleValues[0]);

            for (int i = 1; i < sampleValues.Length; i++)
            {
                if (occurences.Count == 0)
                {
                    occurences.Push(sampleValues[i]);
                }
                else
                {
                    if (occurences.Peek() == sampleValues[i])
                    {
                        occurences.Push(sampleValues[i]);
                    }
                    else
                    {
                        occurences.Pop();
                    }
                }
            }

            int possibleMajorant = occurences.Peek();
            int possibleMajorantOccurences = 0;

            for (int i = 0; i < sampleValues.Length; i++)
            {
                if (sampleValues[i] == possibleMajorant)
                {
                    possibleMajorantOccurences++;
                }
            }

            if (possibleMajorantOccurences >= sampleValues.Length / 2 + 1)
            {
                Console.WriteLine("{0} is the majorant.", possibleMajorant);
            }
            else
            {
                Console.WriteLine("The array does not have a majorant.");
            }
        }
    }
}
