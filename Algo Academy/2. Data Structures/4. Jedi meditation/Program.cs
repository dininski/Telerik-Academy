using System;
using System.Collections.Generic;
using System.Text;

namespace Jedi_Meditation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var masters = new HashSet<string>();
            var knights = new HashSet<string>();
            var padawans = new HashSet<string>();

            int numberOfJedi = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            string[] jedis = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < jedis.Length; i++)
            {
                char firstChar = jedis[i][0];
                if (firstChar == 'm')
                {
                    masters.Add(jedis[i]);
                }
                else if (firstChar == 'k')
                {
                    knights.Add(jedis[i]);
                }
                else
                {
                    padawans.Add(jedis[i]);
                }
            }

            StringBuilder result = new StringBuilder();

            result.Append(string.Join(" ", masters));
            result.Append(" ");
            result.Append(string.Join(" ", knights));
            result.Append(" ");
            result.Append(string.Join(" ", padawans));

            Console.WriteLine(result.ToString());
        }
    }
}