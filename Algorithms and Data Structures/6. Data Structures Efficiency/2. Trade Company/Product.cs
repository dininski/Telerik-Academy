namespace TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product : IComparable<Product>
    {
        public Product(string title, decimal price, string barcode, string vendor)
        {
            this.Title = title;
            this.Price = price;
            this.Barcode = barcode;
            this.Vendor = vendor;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return string.Format("Product title: {0}, price: {1:0.00}, barcode: {2}, vendor: {3}", this.Title, this.Price, this.Barcode, this.Vendor);
        }
    }
}
