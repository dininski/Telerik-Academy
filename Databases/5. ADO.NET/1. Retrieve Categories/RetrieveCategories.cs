// 1. Write a program that retrieves from the Northwind sample database in MS SQL
// Server the number of  rows in the Categories table.
namespace RetrieveCategories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RetrieveCategories
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
                "Database=Northwind;Integrated Security = true");

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand commandCount = new SqlCommand("SELECT COUNT(CategoryId) FROM Categories;", dbConnection);
                int categoriesCount = (int)commandCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0}", categoriesCount);
            }
        }
    }
}