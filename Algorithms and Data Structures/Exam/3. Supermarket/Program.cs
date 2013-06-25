namespace Supermarket
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Supermarket market = new Supermarket();
            StringBuilder result = new StringBuilder();
            while (input != "End")
            {
                string[] command = input.Split(' ');

                switch (command[0])
                {
                    case "Append":
                        result.AppendLine(market.Append(command[1]));
                        break;
                    case "Serve":
                        result.AppendLine(market.Serve(int.Parse(command[1])));
                        break;
                    case "Insert":
                        result.AppendLine(market.Insert(int.Parse(command[1]), command[2]));
                        break;
                    case "Find":
                        result.AppendLine(market.Find(command[1]));
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(result.ToString());
        }
    }

    public class Supermarket
    {
        BigList<string> people;
        Dictionary<string, int> byName;

        public Supermarket()
        {
            this.byName = new Dictionary<string, int>();
            this.people = new BigList<string>();
        }

        public string Find(string name)
        {
            if (this.byName.ContainsKey(name))
            {
                return this.byName[name].ToString();
            }

            return "0";
        }

        public string Append(string name)
        {
            this.people.Add(name);

            if (!this.byName.ContainsKey(name))
            {
                this.byName.Add(name, 0);
            }

            this.byName[name]++;

            return "OK";
        }

        public string Serve(int serveCount)
        {
            if (serveCount > this.people.Count)
            {
                return "Error";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                var toServe = this.people.Range(0, serveCount);

                foreach (var item in toServe)
                {
                    sb.AppendFormat("{0} ", item);
                    this.byName[item]--;
                }

                sb.Length--;
                this.people.RemoveRange(0, serveCount);
                return sb.ToString();
            }
        }

        public string Insert(int position, string name)
        {
            if (position > this.people.Count)
            {
                return "Error";
            }

            this.people.Insert(position, name);
            if (!this.byName.ContainsKey(name))
            {
                this.byName.Add(name, 0);
            }

            this.byName[name]++;

            return "OK";
        }
    }
}
