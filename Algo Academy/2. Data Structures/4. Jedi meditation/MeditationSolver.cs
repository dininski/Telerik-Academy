using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace Jedi_Meditation
{
    public class MeditationSolver
    {
        private OrderedBag<string> meditatorsPriorityQueue;
        private string[] meditators;

        public MeditationSolver(int totalMeditators, string inputString)
        {
            meditatorsPriorityQueue = new OrderedBag<string>(JediComparer);
            this.meditators = inputString.Split(' ');

            for (int i = 0; i < totalMeditators; i++)
            {
                meditatorsPriorityQueue.Add(meditators[i]);
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

        private static int JediComparer(string first, string second)
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
