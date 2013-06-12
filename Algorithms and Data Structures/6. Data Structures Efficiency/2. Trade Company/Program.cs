namespace TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static Random generator = new Random();

        static void Main(string[] args)
        {
            ProductCatalog catalog = new ProductCatalog();

            Console.WriteLine("Adding products...");
            for (int i = 0; i < 1000000; i++)
            {
                Product newProd = new Product(GenerateString(), (decimal)(generator.NextDouble() * 1000),
                    GenerateString(), GenerateString());

                catalog.AddProduct(newProd);
            }
            Console.WriteLine("Finished adding products");

            var results = catalog.ProductsInRange(10, 20);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static string GenerateString()
        {
            StringBuilder currentString = new StringBuilder();
            int length = generator.Next(4, 10);
            for (int i = 0; i < length; i++)
            {
                char currentChar = (char)(generator.Next('a','z'));
                currentString.Append(currentChar);
            }

            return currentString.ToString();
        }
    }
}
