namespace ProductsInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductsManager
    {
        private readonly OrderedBag<Product> productsBag;

        public ProductsManager()
        {
            this.productsBag = new OrderedBag<Product>();
        }

        public void Add(Product newProduct)
        {
            this.productsBag.Add(newProduct);
        }

        public IEnumerable<Product> ProductsInRange(decimal lower, decimal higher)
        {
            var results = productsBag.Range(new Product("lower", lower), true, new Product("higher", higher), true).Take(20);
            return results;
        }
    }
}
