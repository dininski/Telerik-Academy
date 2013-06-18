namespace AllSubsets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetsGenerator<T>
    {
        private readonly T[] elements;
        private T[] result;

        public SubsetsGenerator(IEnumerable<T> elements)
        {
            this.elements = elements.ToArray();
        }

        public void PrintSubsets(int max)
        {
            result = new T[max];
            GenerateSubsets(0, 0);
        }

        private void GenerateSubsets(int start, int current)
        {
            if (start >= this.result.Length)
            {
                Print(this.result);
            }
            else
            {
                for (int i = current; i < this.elements.Length; i++)
                {
                    this.result[start] = this.elements[i];
                    GenerateSubsets(start + 1, i + 1);
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
