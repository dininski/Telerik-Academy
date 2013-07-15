namespace AllProductsAndCategories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductsAndCategories
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
                "Database=Northwind;Integrated Security = true");

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command = new SqlCommand("SELECT c.CategoryName, c.Description, p.ProductName FROM Categories c " +
                    "join products p on c.CategoryID = p.CategoryId ORDER BY c.CategoryName, p.ProductName", dbConnection);

                var commandReader = command.ExecuteReader();

                using (commandReader)
                {
                    while (commandReader.Read())
                    {
                        Console.WriteLine("Product: {0}, Category name: {1}, Category description: {2}",
                            commandReader["ProductName"], commandReader["CategoryName"], commandReader["Description"]);
                    }
                }
            }
        }
    }
}
