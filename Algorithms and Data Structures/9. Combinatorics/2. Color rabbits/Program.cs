namespace _2.Color_rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> rabbits = new Dictionary<int, int>();

            int inputCount = int.Parse(Console.ReadLine());
            int rabbitsCount = 0;


            for (int i = 0; i < inputCount; i++)
            {
                int current = int.Parse(Console.ReadLine());
                if (!rabbits.ContainsKey(current))
                {
                    rabbits.Add(current, 0);
                }

                if (rabbits[current] != current + 1)
                {
                    rabbits[current]++;
                }
                else
                {
                    rabbits[current] = 1;
                    rabbitsCount += current + 1;
                }
            }

            foreach (var item in rabbits)
            {
                if (item.Value > 0)
                {
                    rabbitsCount += item.Key + 1;                    
                }
            }

            Console.WriteLine(rabbitsCount);
        }
    }
}
