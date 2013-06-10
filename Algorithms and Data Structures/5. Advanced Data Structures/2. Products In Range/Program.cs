namespace ProductsInRange
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ProductsManager pm = new ProductsManager();
            Random generator = new Random();
            Console.WriteLine("Filling bag with random values...");

            for (int productsCount = 0; productsCount < 500000; productsCount++)
            {
                // using numbers as product names for easier generating
                pm.Add(new Product(generator.Next(1, 100000).ToString(), (decimal)(generator.NextDouble() * 10000)));
            }

            Console.WriteLine("Finished filling bag.");

            Stopwatch sw = new Stopwatch();
            List<IEnumerable<Product>> searchResults = new List<IEnumerable<Product>>();
            
            // starting the searches
            sw.Start();

            for (int searchesCount = 0; searchesCount < 20000; searchesCount++)
            {
                // adding each search result to a list for easier displaying later
                searchResults.Add(pm.ProductsInRange((decimal)generator.NextDouble() * 10000, (decimal)generator.NextDouble() * 10000));
            }

            // finished the searches
            sw.Stop();

            Console.WriteLine("Searches finished in {0} and saved in a list!", sw.Elapsed);
            Console.WriteLine("To display the results press enter");
            Console.ReadLine();
            DisplayProducts(searchResults);
        }

        public static void DisplayProducts(List<IEnumerable<Product>> searchResults)
        {
            foreach (var searchResult in searchResults)
            {
                Console.WriteLine("Products: ");
                foreach (var product in searchResult)
                {
                    Console.WriteLine("{0} -> {1}", product.Name, product.Price);
                }
            }
        }
    }
}
