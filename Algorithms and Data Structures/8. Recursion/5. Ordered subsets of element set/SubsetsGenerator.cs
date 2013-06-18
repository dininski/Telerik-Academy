namespace OrderedSubsets
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
            GenerateSubsets(0, new T[max], max);
        }

        private void GenerateSubsets(int index, T[] result, int max)
        {
            if (index == max)
            {
                Print(result);
            }
            else
            {
                for (int i = 0; i < this.Elements.Length; i++)
                {
                    result[index] = this.Elements[i];
                    GenerateSubsets(index + 1, result, max);
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
