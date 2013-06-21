namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        static readonly string notFound = "No products found";

        public static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            Command command;
            Center mall = new Center();

            for (int i = 0; i < commandsCount; i++)
            {
                command = Command.Parse(Console.ReadLine());

                switch (command.Type)
                {
                    case "AddProduct":
                        string productName = command.Arguments[0];
                        decimal productPrice = decimal.Parse(command.Arguments[1]);
                        string productProducer = command.Arguments[2];
                        Product prod = new Product(productName, productPrice, productProducer);

                        mall.AddProduct(prod);
                        result.AppendLine("Product added");
                        break;
                    case "DeleteProducts":
                        if (command.Arguments.Length == 1)
                        {
                            result.AppendLine(mall.DeleteProductsByProducer(command.Arguments[0]));
                        }
                        else
                        {
                            result.AppendLine(mall.DeleteProductsByNameAndProducer(command.Arguments[0] + command.Arguments[1]));
                        }

                        break;
                    case "FindProductsByName":
                        string nameToSearch = command.Arguments[0];
                        var productsByName = mall.FindProductsByName(nameToSearch);
                        if (productsByName.Count() != 0)
                        {
                            foreach (var product in productsByName)
                            {
                                result.AppendLine(product.ToString());
                            }
                        }
                        else
                        {
                            result.AppendLine(notFound);
                        }

                        break;
                    case "FindProductsByPriceRange":
                        decimal lowerLimit = decimal.Parse(command.Arguments[0]);
                        decimal upperLimit = decimal.Parse(command.Arguments[1]);
                        var productsByPrice = mall.FindProductsInRange(lowerLimit, upperLimit);
                        if (productsByPrice.Count() != 0)
                        {
                            foreach (var product in productsByPrice)
                            {
                                result.AppendLine(product.ToString());
                            }
                        }
                        else
                        {
                            result.AppendLine(notFound);
                        }

                        break;
                    case "FindProductsByProducer":
                        string producer = command.Arguments[0];
                        var productsByProducer = mall.GetProductsByProducer(producer);
                        if (productsByProducer.Count() != 0)
                        {
                            foreach (var product in productsByProducer)
                            {
                                result.AppendLine(product.ToString());
                            }
                        }
                        else
                        {
                            result.AppendLine(notFound);
                        }

                        break;
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }

        public class Command
        {
            public Command(string type, string[] args)
            {
                this.Type = type;
                this.Arguments = args;
            }

            public static Command Parse(string commandString)
            {
                int indexOfSpace = commandString.IndexOf(' ');
                string commandType;
                string[] argumens;
                if (indexOfSpace > 0)
                {
                    commandType = commandString.Substring(0, indexOfSpace);
                    string args = commandString.Substring(indexOfSpace + 1);
                    argumens = args.Split(';');
                }
                else
                {
                    commandType = commandString;
                    argumens = new string[1];
                }

                return new Command(commandType, argumens);
            }

            public string Type { get; set; }

            public string[] Arguments { get; set; }
        }

        public class Product : IComparable<Product>
        {
            public Product(string name, decimal price, string producer)
            {
                this.Name = name;
                this.Price = price;
                this.Producer = producer;
            }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Producer { get; set; }

            public override string ToString()
            {
                return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
            }

            public int CompareTo(Product other)
            {
                int nameComparison = this.Name.CompareTo(other.Name);

                if (nameComparison == 0)
                {
                    return this.Producer.CompareTo(other.Producer);
                }

                return nameComparison;
            }
        }

        public class Center
        {
            readonly MultiDictionary<string, Product> productsByName;
            readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
            readonly MultiDictionary<string, Product> productsByProducer;
            readonly MultiDictionary<string, Product> productsByNameAndProducer;

            public Center()
            {
                this.productsByName = new MultiDictionary<string, Product>(true);
                this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
                this.productsByProducer = new MultiDictionary<string, Product>(true);
                this.productsByNameAndProducer = new MultiDictionary<string, Product>(true);
            }

            public void AddProduct(Product newProduct)
            {
                this.productsByName.Add(newProduct.Name, newProduct);
                this.productsByPrice.Add(newProduct.Price, newProduct);
                this.productsByProducer.Add(newProduct.Producer, newProduct);
                StringBuilder sb = new StringBuilder();
                sb.Append(newProduct.Name);
                sb.Append(newProduct.Producer);
                this.productsByNameAndProducer.Add(sb.ToString(), newProduct);
            }

            public IEnumerable<Product> FindProductsByName(string name)
            {
                if (this.productsByName.ContainsKey(name))
                {
                    OrderedBag<Product> prodByName = new OrderedBag<Product>(productsByName[name]);
                    return prodByName;
                }
                else
                {
                    return new List<Product>();
                }
            }

            public IEnumerable<Product> FindProductsInRange(decimal lower, decimal upper)
            {
                var byPrice = this.productsByPrice.Range(lower, true, upper, true).Values;
                OrderedBag<Product> ordered = new OrderedBag<Product>(byPrice);
                return ordered;
            }

            public IEnumerable<Product> GetProductsByProducer(string producer)
            {
                if (this.productsByProducer.ContainsKey(producer))
                {
                    OrderedBag<Product> producers = new OrderedBag<Product>(this.productsByProducer[producer]);
                    return producers;
                }
                else
                {
                    return new List<Product>();
                }
            }

            public string DeleteProductsByProducer(string producer)
            {
                if (!this.productsByProducer.ContainsKey(producer))
                {
                    return notFound;
                }
                else
                {
                    HashSet<Product> productsToDelete = new HashSet<Product>(this.productsByProducer[producer]);
                    int productsCount = productsToDelete.Count;

                    foreach (var product in productsToDelete)
                    {
                        this.productsByName.Remove(product.Name, product);
                        this.productsByPrice.Remove(product.Price, product);
                        StringBuilder sb = new StringBuilder();
                        sb.Append(product.Name);
                        sb.Append(product.Producer);
                        this.productsByNameAndProducer.Remove(sb.ToString(), product);
                        this.productsByProducer.Remove(product.Producer, product);
                    }

                    return string.Format("{0} products deleted", productsCount);
                }
            }

            public string DeleteProductsByNameAndProducer(string productAndProducer)
            {
                if (!this.productsByNameAndProducer.ContainsKey(productAndProducer))
                {
                    return notFound;
                }
                else
                {
                    HashSet<Product> productsToDelete = new HashSet<Product>(this.productsByNameAndProducer[productAndProducer]);
                    int productsCount = productsToDelete.Count;
                    StringBuilder sb = new StringBuilder();
                    foreach (var product in productsToDelete)
                    {
                        sb.Append(product.Name);
                        sb.Append(product.Producer);
                        productsByName.Remove(product.Name, product);
                        productsByPrice.Remove(product.Price, product);
                        productsByNameAndProducer.Remove(sb.ToString(), product);
                        productsByProducer.Remove(product.Producer, product);
                        sb = new StringBuilder();
                    }

                    return string.Format("{0} products deleted", productsCount);
                }
            }
        }
    }
}
