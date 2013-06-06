namespace MostCommon
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        public static void Main()
        {
            int numberOfEntries = int.Parse(Console.ReadLine());
            Dictionary<string, int> firstNames = new Dictionary<string, int>();
            Dictionary<string, int> lastNames = new Dictionary<string, int>();
            Dictionary<string, int> years = new Dictionary<string, int>();
            Dictionary<string, int> eyes = new Dictionary<string, int>();
            Dictionary<string, int> hairs = new Dictionary<string, int>();
            Dictionary<string, int> heights = new Dictionary<string, int>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string input = Console.ReadLine();
                var args = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = args[0];
                AddCharacteristic(firstNames, firstName);
                string lastName = args[1];
                AddCharacteristic(lastNames, lastName);
                string year = args[2];
                AddCharacteristic(years, year);
                string eyeColor = args[3];
                AddCharacteristic(eyes, eyeColor);
                string hairColor = args[4];
                AddCharacteristic(hairs, hairColor);
                string height = args[5];
                AddCharacteristic(heights, height);
            }
            Console.WriteLine(GetMax(firstNames));
            Console.WriteLine(GetMax(lastNames));
            Console.WriteLine(GetMax(years));
            Console.WriteLine(GetMax(eyes));
            Console.WriteLine(GetMax(hairs));
            Console.WriteLine(GetMax(heights));
        }

        public static void AddCharacteristic(Dictionary<string, int> dict, string characteristic)
        {
            if (!dict.ContainsKey(characteristic))
            {
                dict.Add(characteristic, 0);
            }
            dict[characteristic]++;
        }

        public static string GetMax(Dictionary<string, int> dict)
        {
            string best = "";
            int occurences = 0;

            foreach (var item in dict)
            {
                if (item.Value > occurences)
                {
                    best = item.Key;
                    occurences = item.Value;
                }
                else if (item.Value == occurences)
                {
                    best = string.Compare(best, item.Key) == 1 ? item.Key : best;
                }
            }

            return best;
        }
    }
}