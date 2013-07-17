using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessLayer;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Northwind.Context;

namespace Northwind.ConsoleDemos
{
    public class ConsoleDemos
    {
        public static void Main()
        {
            #region Problem 2 - Add, Modify and Delete
            NorthwindDAO.AddCustomer("ALABA", "Pesho Peshov", "Owner",
                "555-123123", "555-123124", "Dolno uino", "1000", "Sofia",
                "Sofia-grad", "Bulgaria", "McDonalds");

            var customerName = NorthwindDAO.GetCustomerNameById("ALABA");

            Console.WriteLine("Customer name will be blank if no entry found.");

            Console.WriteLine("Name for customer with id ALABA: {0}", customerName);

            NorthwindDAO.ModifyCustomer("ALABA", "Gosho Goshov", "Employee",
                "555-123123", "555-123124", "Gorno uino", "9999", "Pleven",
                "Plovdiv", "Bulgaria", "KFC");

            customerName = NorthwindDAO.GetCustomerNameById("ALABA");
            Console.WriteLine("Name for customer with id ALABA: {0}", customerName);

            NorthwindDAO.DeleteCustomer("ALABA");

            customerName = NorthwindDAO.GetCustomerNameById("ALABA") ?? "";
            Console.WriteLine("Name for customer with id ALABA: {0}", customerName);
            #endregion

            #region Problem 3 - Get by year and location
            var customerNames = NorthwindDAO.GetCustomersByYearAndLocation("Canada", 1997);

            foreach (var name in customerNames)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region Problem 4 - Native SQL query
            var queryResult = NorthwindDAO.ExecuteQuery("SELECT c.ContactName FROM Customers c " +
                "INNER JOIN Orders o ON o.CustomerId = c.CustomerId " +
                "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1})", new object[] { 1997, "Canada" }).Distinct();

            foreach (var result in queryResult)
            {
                Console.WriteLine(result);
            }
            #endregion

            #region Problem 5 - All sales by region and period
            var orders = NorthwindDAO.SalesByRegionAndDate("CA",
                new DateTime(1000, 1, 1), new DateTime(2000, 1, 1));

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            #endregion

            #region Problem 6 - Twin database
            string createNorthwindCloneDBCommand = @"CREATE DATABASE NorthwindTwin ON PRIMARY 
(NAME = NorthwindTwin, FILENAME = 'D:\NorthwindTwin.mdf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) 
LOG ON (NAME = NorthwindTwinLog, FILENAME = 'D:\NorthwindTwin.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";
            SqlConnection dbConnectionForCreatingDB =
                new SqlConnection("Server=localhost;Database=master;Integrated Security=true");
            dbConnectionForCreatingDB.Open();
            using (dbConnectionForCreatingDB)
            {
                SqlCommand createDBCommand =
                    new SqlCommand(createNorthwindCloneDBCommand, dbConnectionForCreatingDB);
                createDBCommand.ExecuteNonQuery();
            }

            IObjectContextAdapter northwindContext = new NorthwindEntities();
            string cloneNorthwindScript = northwindContext.ObjectContext.CreateDatabaseScript();
            SqlConnection dbConnectionForCloningDB = new SqlConnection("Server=localhost;Database=NorthwindTwin;Integrated Security=true");
            dbConnectionForCloningDB.Open();
            using (dbConnectionForCloningDB)
            {
                SqlCommand cloneDBCommand = new SqlCommand(cloneNorthwindScript, dbConnectionForCloningDB);
                cloneDBCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Cloning done!");
            #endregion

            #region Problem 7 - Two dbcontext - solved using Singleton pattern
            Console.WriteLine("Using double context...");
            NorthwindDAO.DoubleContext();
            Console.WriteLine("Done");
            #endregion

            #region Problem 8 - Employee inheritance
            NorthwindDAO.Inheritance();
            #endregion

            #region Problem 9 - 
            NorthwindDAO.CreateOrder();
            Console.WriteLine("Order added");
            #endregion
        }
    }
}
