using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern_Example
{
    public class ObserverExample
    {
        public static void Main(string[] args)
        {
            // the movie catalog is the subject, that will be 
            // observed for changes
            MovieCatalog hbo = new MovieCatalog();

            // the subscribers are the observers and they are 
            // added as observer to the movie catalog
            Subscriber gosho = new Subscriber("Pesho");
            hbo.AddSubscriber(gosho);

            Subscriber pesho = new Subscriber("Gosho");
            hbo.AddSubscriber(pesho);

            // once a new movie is added all the observers are
            // notified
            hbo.NewMovieAdded();
        }
    }
}
