namespace TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class ProductCatalog
    {
        OrderedMultiDictionary<decimal, Product> store;

        public ProductCatalog()
        {
            this.store = new OrderedMultiDictionary<decimal, Product>(true);
        }

        public void AddProduct(Product newProduct)
        {
            this.store.Add(newProduct.Price, newProduct);
        }

        public IEnumerable<Product> ProductsInRange(decimal lower, decimal higher)
        {
            var pricesInRange = this.store.Range(lower, true, higher, true);
            List<Product> products = new List<Product>();

            foreach (var productsWithSamePrice in pricesInRange)
            {
                foreach (var product in productsWithSamePrice.Value)
                {
                    products.Add(product);
                }
            }

            return products;
        }
    }
}
