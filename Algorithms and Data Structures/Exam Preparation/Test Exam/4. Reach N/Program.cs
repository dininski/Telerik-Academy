namespace _4.Reach_N
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                var start = new KeyValuePair<BigInteger, int>(1, 0);
                BigInteger desired = BigInteger.Parse(Console.ReadLine());
                var results = new OrderedBag<KeyValuePair<BigInteger, int>>((x, y) => x.Value.CompareTo(y.Value));
                results.Add(start);

                var current = start;

                HashSet<BigInteger> used = new HashSet<BigInteger>();
                while (current.Key != desired)
                {
                    current = results.RemoveFirst();
                    if (!used.Contains(current.Key))
                    {
                        results.Add(new KeyValuePair<BigInteger, int>(current.Key + 1, current.Value + 1));

                        if (current.Key != 1)
                        {
                            BigInteger toPower = 1;
                            List<BigInteger> powers = new List<BigInteger>();
                            while (toPower <= desired - 1)
                            {
                                toPower *= current.Key;
                                powers.Add(toPower);
                            }

                            powers.Reverse();

                            foreach (var item in powers)
                            {
                                if (item <= desired + 1 && !used.Contains(item))
                                {
                                    if (!used.Contains(item))
                                    {
                                        results.Add(new KeyValuePair<BigInteger, int>(item, current.Value + 1));
                                    }

                                    if (!used.Contains(item - 1))
                                    {
                                        results.Add(new KeyValuePair<BigInteger, int>(item - 1, current.Value + 2));
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
    }
}
