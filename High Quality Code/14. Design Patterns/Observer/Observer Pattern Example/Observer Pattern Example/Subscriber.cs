using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern_Example
{
    public class Subscriber : ISubscriber
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void NotifyNewMovie()
        {
            Console.WriteLine("{0} was notified that there is a new movie in the catalog", this.Name);
        }
    }
}
