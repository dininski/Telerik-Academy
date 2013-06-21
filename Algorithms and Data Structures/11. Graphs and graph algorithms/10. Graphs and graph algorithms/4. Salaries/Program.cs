namespace Salaries
{
    using System;

    public class Program
    {
        static bool[,] employees;
        static long[] salaries;
        static int numberOfEmployees;

        static void Main(string[] args)
        {
            numberOfEmployees = int.Parse(Console.ReadLine());
            employees = new bool[numberOfEmployees, numberOfEmployees];
            salaries = new long[numberOfEmployees];

            for (int col = 0; col < numberOfEmployees; col++)
            {
                string rowString = Console.ReadLine();

                for (int row = 0; row < numberOfEmployees; row++)
                {
                    if (rowString[row] == 'Y')
                    {
                        employees[col, row] = true;
                    }
                }
            }

            long sumOfSalaries = 0;

            for (int i = 0; i < numberOfEmployees; i++)
            {
                sumOfSalaries += FindSalary(i);
            }

            Console.WriteLine(sumOfSalaries);
        }

        static long FindSalary(int employee)
        {
            if (salaries[employee] > 0)
            {
                return salaries[employee];
            }
            else
            {
                long salary = 0;
                for (int i = 0; i < numberOfEmployees; i++)
                {
                    if (employees[employee, i])
                    {
                        salary += FindSalary(i);
                    }
                }

                if (salary == 0)
                {
                    salary = 1;
                }

                salaries[employee] = salary;

                return salary;
            }

        }
    }
}
