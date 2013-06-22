namespace RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> visited = new HashSet<string>();
            string startNumber = Console.ReadLine();
            visited.Add(startNumber);
            string endNumber = Console.ReadLine();

            int forbiddenNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < forbiddenNumbers; i++)
            {
                visited.Add(Console.ReadLine());
            }

            Tuple<string, int> startNum = new Tuple<string, int>(startNumber, 0);

            Queue<Tuple<string, int>> bfs = new Queue<Tuple<string, int>>();
            bfs.Enqueue(startNum);
            StringBuilder sb = new StringBuilder();

            while (bfs.Count > 0)
            {
                var current = bfs.Dequeue();

                sb = new StringBuilder(current.Item1);

                for (int i = 0; i < 5; i++)
                {
                    int currentNum = current.Item1[i] - '0';
                    currentNum++;
                    if (currentNum == 10)
                    {
                        currentNum = 0;
                    }

                    sb[i] = (char)(currentNum + '0');
                    if (!visited.Contains(sb.ToString()))
                    {
                        bfs.Enqueue(new Tuple<string, int>(sb.ToString(), current.Item2 + 1));
                        visited.Add(sb.ToString());
                    }

                    sb[i] = current.Item1[i];
                }

                for (int i = 0; i < 5; i++)
                {
                    int currentNum = current.Item1[i] - '0';
                    currentNum--;
                    if (currentNum == -1)
                    {
                        currentNum = 9;
                    }

                    sb[i] = (char)(currentNum + '0');

                    if (!visited.Contains(sb.ToString()))
                    {
                        bfs.Enqueue(new Tuple<string, int>(sb.ToString(), current.Item2 + 1));
                        visited.Add(sb.ToString());
                    }

                    sb[i] = current.Item1[i];
                }

                if (current.Item1.Equals(endNumber))
                {
                    Console.WriteLine(current.Item2);
                    return;
                }
            }

            Console.WriteLine(-1);

        }
    }
}