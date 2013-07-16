using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Northwind.Context;
using System.Data.Entity.Validation;
using System.Data.Metadata.Edm;

namespace Northwind.DataAccessLayer
{
    public static class NorthwindDAO
    {
        public static class Northwind
        {
            private static NorthwindEntities db;

            public static NorthwindEntities GetInstance()
            {
                if (db == null)
                {
                    db = new NorthwindEntities();
                }

                return db;
            }
        }

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

        public static void DoubleDbContext()
        {
            NorthwindEntities firstDbContext = Northwind.GetInstance();
            NorthwindEntities secondDbContext = Northwind.GetInstance();

            using (firstDbContext)
            {
                using (secondDbContext)
                {
                    Customer customer1 = firstDbContext.Customers.Find("CHOPS");
                    customer1.Region = "CAN";

                    Customer customer2 = secondDbContext.Customers.Find("CHOPS");
                    customer2.Region = "BUL";

                    firstDbContext.SaveChanges();
                    secondDbContext.SaveChanges();
                }
            }

        }

        public static EntitySet GetEmployeesWithTerritories()
        {
            // TODO
            throw new NotImplementedException();
            
        }
    }
}
