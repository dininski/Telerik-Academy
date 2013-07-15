namespace AddNewProduct
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddProduct
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a product name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Is the product visible? (1 for discontinued, 0 for not discontinued");
            int discontinuedAsInt = int.Parse(Console.ReadLine());

            bool discontinued = (discontinuedAsInt == 0);

            AddAProduct(name, discontinuedAsInt);

            Console.WriteLine("Done");
        }

        public static void AddAProduct(string name, int discontinued)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
                "Database=Northwind;Integrated Security = true");

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Products(ProductName, Discontinued) VALUES(@name, @discontinued)", dbConnection);

                command.Parameters.Add("@name", name);
                command.Parameters.Add("@discontinued", discontinued);

                command.ExecuteNonQuery();
            }
        }
    }
}
