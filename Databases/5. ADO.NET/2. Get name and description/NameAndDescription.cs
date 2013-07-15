// 2. Write a program that retrieves the name and description of all
// categories in the Northwind DB.
namespace GetNameAndDescription
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class NameAndDescription
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
                "Database=Northwind;Integrated Security = true");

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);

                var commandReader = command.ExecuteReader();

                using (commandReader)
                {
                    while (commandReader.Read())
                    {
                        Console.WriteLine("Category name: {0}, Category description: {1}",
                            commandReader["CategoryName"], commandReader["Description"]);
                    }
                }
            }
        }
    }
}
