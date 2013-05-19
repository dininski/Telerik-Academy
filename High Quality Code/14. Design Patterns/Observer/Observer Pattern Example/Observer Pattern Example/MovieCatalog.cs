using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern_Example
{
    public class MovieCatalog
    {
        List<ISubscriber> subscribers;

        public MovieCatalog()
        {
            this.subscribers = new List<ISubscriber>();
        }


        public void AddSubscriber(ISubscriber subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            this.subscribers.Remove(subscriber);
        }

        public void NewMovieAdded()
        {
            foreach (Subscriber subscriber in subscribers)
            {
                subscriber.NotifyNewMovie();
            }
        }
    }
}
