using System;

namespace ACompany
{
    class ACompany
    {
        static void Main()
        {
            string companyName;
            string companyAddress;
            int companyPhone;
            int companyFax;
            string companyWebsite;
            string manager;
            string managerFirstName;
            string managerLastName;
            int managerAge;
            int managerPhoneNumber;

            Console.WriteLine("Enter company name:");
            companyName = Console.ReadLine();
            Console.WriteLine("Company address:");
            companyAddress = Console.ReadLine();
            Console.WriteLine("Company phone number: ");
            companyPhone = int.Parse(Console.ReadLine());
            Console.WriteLine("Company fax number:");
            companyFax = int.Parse(Console.ReadLine());
            Console.WriteLine("Company website:");
            companyWebsite = Console.ReadLine();
            Console.WriteLine("The manager's first name:");
            managerFirstName = Console.ReadLine();
            Console.WriteLine("The manager's last name:");
            managerLastName = Console.ReadLine();
            manager = managerFirstName + " " + managerLastName;
            Console.WriteLine("The manager's age: ");
            managerAge = int.Parse(Console.ReadLine());
            Console.WriteLine("The manager's phone number: ");
            managerPhoneNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Company: {0}", companyName);
            Console.WriteLine("Company address: {0}", companyAddress);
            Console.WriteLine("Company phone number: {0}", companyPhone);
            Console.WriteLine("Company fax number: {0}", companyFax);
            Console.WriteLine("Company website: {0}", companyWebsite);
            Console.WriteLine("The company manager: {0}, (age: {1}), phone number: {2}", manager, managerAge, managerPhoneNumber);
        }
    }
}
