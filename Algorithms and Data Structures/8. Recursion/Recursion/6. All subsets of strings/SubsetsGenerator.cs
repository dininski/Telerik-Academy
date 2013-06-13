namespace AllSubsets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetsGenerator<T>
    {
        private T[] Elements;

        public SubsetsGenerator(IEnumerable<T> elements)
        {
            this.Elements = elements.ToArray();
        }

        public void PrintSubsets(int max)
        {
            GenerateSubsets(0, new T[max], 0, max);
        }

        private void GenerateSubsets(int index, T[] result, int start, int max)
        {
            if (index == max)
            {
                Print(result);
            }
            else
            {
                for (int i = start; i <= max; i++)
                {

                }
            }

        }

        private void Print(T[] items)
        {
            foreach (var item in items)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }
    }
}
