using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Academy_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbersAsStrings = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfElements = numbersAsStrings.Count();
            int threshold = int.Parse(Console.ReadLine());
            int[,] solutionMatrix = new int[numberOfElements + 1, numberOfElements + 1];

            for (int i = 1; i < numberOfElements; i++)
            {
                solutionMatrix[0, i] = int.Parse(numbersAsStrings[i]);
            }

            solutionMatrix[1, 1] = 1;

            for (int col = 1; col < numberOfElements; col++)
            {
                for (int row = 1; row < numberOfElements - 1; row++)
                {
                    if (solutionMatrix[col, row] != 0)
                    {
                        int firstResult = Math.Abs(solutionMatrix[0, 1] - solutionMatrix[0, row + 1]);

                        if (firstResult >= threshold)
                        {
                            Console.WriteLine(col + 1);
                            return;
                        }
                        else
                        {
                            solutionMatrix[col + 1, row + 1] = 1;
                        }


                        int secondResult = Math.Abs(solutionMatrix[0, 1] - solutionMatrix[0, row + 2]);
                        if (secondResult >= threshold)
                        {
                            Console.WriteLine(col + 1);
                            return;
                        }
                        else
                        {
                            solutionMatrix[col + 1, row + 2] = 1;
                        }
                    }
                }
            }
        }
    }
}
