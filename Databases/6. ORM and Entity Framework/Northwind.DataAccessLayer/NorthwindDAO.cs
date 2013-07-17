using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Northwind.Context;
using System.Data.Entity.Validation;
using System.Data.Metadata.Edm;
using System.Data.Linq;

namespace Northwind.DataAccessLayer
{
    public static class NorthwindDAO
    {
        public static void AddCustomer(string id, string name, string title, string phone,
            string fax, string address, string postalCode, string city, string region,
            string country, string company)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                Customer customer = new Customer();
                customer.CustomerID = id;
                customer.ContactName = name;
                customer.ContactTitle = title;
                customer.Phone = phone;
                customer.Fax = fax;
                customer.Address = address;
                customer.PostalCode = postalCode;
                customer.City = city;
                customer.Region = region;
                customer.Country = country;
                customer.CompanyName = company;

                if (northwind.Customers.Find(id) == null)
                {
                    northwind.Customers.Add(customer);
                }

                northwind.SaveChanges();
            }
        }

        public static void DeleteCustomer(string id)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                Customer customerToDelete = northwind.Customers.Find(id);
                northwind.Customers.Remove(customerToDelete);
                northwind.SaveChanges();
            }
        }

        public static void ModifyCustomer(string id, string name, string title, string phone,
            string fax, string address, string postalCode, string city, string region,
            string country, string company)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                Customer customerToEdit = northwind.Customers.Find(id);
                customerToEdit.ContactName = name;
                customerToEdit.ContactTitle = title;
                customerToEdit.Phone = phone;
                customerToEdit.Fax = fax;
                customerToEdit.Address = address;
                customerToEdit.PostalCode = postalCode;
                customerToEdit.City = city;
                customerToEdit.Region = region;
                customerToEdit.Country = country;
                customerToEdit.CompanyName = company;

                northwind.Entry(customerToEdit).State = System.Data.EntityState.Modified;
                northwind.SaveChanges();
            }
        }

        public static string GetCustomerNameById(string id)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                var customer = northwind.Customers.Find(id);
                if (customer != null)
                {
                    return customer.ContactName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static IEnumerable<string> GetCustomersByYearAndLocation(string country, int year)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                var customers = northwind.Customers.Where(c =>
                    c.Orders.Where(o =>
                        o.OrderDate.Value.Year == year &&
                        o.ShipCountry == country).Any()
                );

                IEnumerable<string> names = customers.Select(x => x.ContactName).ToList();

                return names;
            }
        }

        public static IEnumerable<string> ExecuteQuery(string query, object[] parameters)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                var queryResult = northwind.Database.SqlQuery<string>(query, parameters).ToList();
                return queryResult;
            }
        }

        public static IEnumerable<string> SalesByRegionAndDate(string region, DateTime start, DateTime end)
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                var result = northwind.Orders.Where(o =>
                    o.ShipRegion == region &&
                    o.OrderDate.Value > start &&
                    o.OrderDate.Value < end).Select(x =>
                        "Contact name: " + x.Customer.ContactName + " Ship address: " +
                        x.ShipAddress).ToList();

                return result;
            }
        }

        public static void CreateNewDatabase(NorthwindEntities northwind)
        {
            // TODO
        }

        public static void DoubleContext()
        {
            using (NorthwindEntities northwindEntities1 = new NorthwindEntities())
            {
                using (NorthwindEntities northwindEntities2 = new NorthwindEntities())
                {
                    Customer customerByFirstDataContext = northwindEntities1.Customers.Find("CHOPS");
                    customerByFirstDataContext.Region = "SW";

                    Customer customerBySecondDataContext = northwindEntities2.Customers.Find("CHOPS");
                    customerBySecondDataContext.Region = "SSWW";

                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();
                }
            }
        }

        public static void Inheritance()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            int employeeID = 1;
            Employee employee = northwindEntities.Employees.Find(employeeID);
            // Property added at Northwind.Data ExtendedEmployee file
            EntitySet<Territory> territories = employee.EntityTerritories;
            Console.WriteLine("All territories for employee with ID {0} are:", employeeID);
            foreach (var territory in territories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
        }

        public static void CreateOrder()
        {
            NorthwindEntities northwind = new NorthwindEntities();

            using (northwind)
            {
                var order = new Order()
                {
                    CustomerID = "BOTTM",
                    EmployeeID = 6,
                    ShipCity = "Sofia",
                    ShipCountry = "Bulgaria",
                    ShippedDate = DateTime.Now,
                    ShipPostalCode = "1000",
                    ShipVia = 2
                };

                var orderDetail1 = new Order_Detail()
                {
                    Order = order,
                    ProductID = 23,
                    Quantity = 10,
                    UnitPrice = 15
                };

                var orderDetail2 = new Order_Detail()
                {
                    Order = order,
                    ProductID = 27,
                    Quantity = 11,
                    UnitPrice = 19
                };

                northwind.Orders.Add(order);
                northwind.Order_Details.Add(orderDetail1);
                northwind.Order_Details.Add(orderDetail2);

                northwind.SaveChanges();
            }
        }
    }
}
