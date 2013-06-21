using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] numbersAsStrings = Console.ReadLine().Split(',');

            int numberOfElements = numbersAsStrings.Count();

            int threshold = int.Parse(Console.ReadLine());

            int first = int.Parse(numbersAsStrings[0]);

            for (int i = 0; i < numberOfElements; i++)
            {
                int current = int.Parse(numbersAsStrings[i]);
                int diff = current - first;

                if (diff >= threshold)
                {
                    Console.WriteLine(1 + (i + 1) / 2);
                    return;
                }
            }

        }
    }
}
