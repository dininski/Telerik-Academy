using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Jedi_Meditation
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string inputString = Console.ReadLine();
            MeditationSolver ms = new MeditationSolver(number, inputString);
            Console.WriteLine(ms.GetMeditationOrder());
        }

        public class MeditationSolver
        {
            private OrderedBag<string> meditatorsPriorityQueue;
            private int meditatorsCount;
            private string[] meditators;

            public MeditationSolver(int totalMeditators, string inputString)
            {
                meditatorsPriorityQueue = new OrderedBag<string>(JediComparer);
                this.meditatorsCount = totalMeditators;
                this.meditators = inputString.Split(' ');

                for (int i = 0; i < meditatorsCount; i++)
                {
                    switch (meditators[i][0])
                    {
                        case 'm':
                            meditatorsPriorityQueue.Add(meditators[i]);
                            break;
                        case 'k':
                            meditatorsPriorityQueue.Add(meditators[i]);
                            break;
                        case 'p':
                            meditatorsPriorityQueue.Add(meditators[i]);
                            break;
                        default:
                            throw new ArgumentException("Invalid jedi format");
                    }
                }
            }

            public string GetMeditationOrder()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in meditatorsPriorityQueue)
                {
                    sb.AppendFormat("{0} ", item);
                }

                return sb.ToString().Trim();
            }

            public static int JediComparer(string first, string second)
            {
                int firstPriority;
                int secondPriority;
                switch (first[0])
                {
                    case 'm':
                        firstPriority = 0;
                        break;
                    case 'k':
                        firstPriority = 1;
                        break;
                    case 'p':
                        firstPriority = 2;
                        break;
                    default:
                        return -2;
                }

                switch (second[0])
                {
                    case 'm':
                        secondPriority = 0;
                        break;
                    case 'k':
                        secondPriority = 1;
                        break;
                    case 'p':
                        secondPriority = 2;
                        break;
                    default:
                        return -2;
                }

                return firstPriority.CompareTo(secondPriority);
            }
        }
    }
}