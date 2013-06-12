namespace _4.Reach_N
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                var start = new KeyValuePair<BigInteger, int>(1, 0);
                BigInteger desired = BigInteger.Parse(Console.ReadLine()); ;
                var results = new Queue<KeyValuePair<BigInteger, int>>();
                results.Enqueue(start);

                var current = start;

                HashSet<BigInteger> used = new HashSet<BigInteger>();
                while (current.Key != desired)
                {
                    current = results.Dequeue();
                    if (!used.Contains(current.Key))
                    {
                        results.Enqueue(new KeyValuePair<BigInteger, int>(current.Key + 1, current.Value + 1));

                        if (current.Key != 1)
                        {
                            BigInteger ToPower = 1;
                            while (ToPower <= desired - 1)
                            {
                                ToPower *= current.Key;
                                if (ToPower <= desired + 1 && !used.Contains(ToPower))
                                {
                                    if (!used.Contains(ToPower))
                                    {
                                        results.Enqueue(new KeyValuePair<BigInteger, int>(ToPower, current.Value + 1));
                                    }

                                    if (!used.Contains(ToPower - 1))
                                    {
                                        results.Enqueue(new KeyValuePair<BigInteger, int>(ToPower - 1, current.Value + 2));
                                    }
                                }
                            }
                        }

                        used.Add(current.Key);
                    }
                }

                Console.WriteLine(current.Value);
            }
        }

        public static BigInteger RaiseTo(BigInteger baseToRaise, int power)
        {
            BigInteger result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseToRaise;
            }

            return result;
        }
    }
}
