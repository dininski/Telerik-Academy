using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessLayer;

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


            #endregion

            #region Problem 7 - Two dbcontext - solved using Singleton pattern
            NorthwindDAO.DoubleDbContext();
            #endregion

            #region Problem 8 - Employee inheritance

            #endregion
        }
    }
}
