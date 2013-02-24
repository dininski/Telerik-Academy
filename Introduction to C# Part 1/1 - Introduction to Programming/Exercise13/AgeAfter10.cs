using System;

namespace ConsoleApplication9
{
    class AgeAfter10
    {
        static void Main()
        {
            System.Console.Write("Please enter your age:");
            int age = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("In 10 years you will be {0} years old",age+10);
        }
    }
}
