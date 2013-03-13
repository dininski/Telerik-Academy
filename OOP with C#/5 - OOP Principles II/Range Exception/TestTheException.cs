using System;

class TestTheException
{
    public static void TestInt(int someNumber)
    {
        
    }

    static void Main(string[] args)
    {
        InvalidRangeException<int> integerException = new InvalidRangeException<int>("Value must be in range 1 - 100", 1, 100);
        InvalidRangeException<DateTime> dateException = new InvalidRangeException<DateTime>("Date must be between 1.1.1980 and 31.12.2013", 
            new DateTime(1980,1,1), new DateTime(2013,12,31));

        Console.WriteLine("Please enter 3 values between 1 and 100 (if you don't want errors)");
        for (int i = 0; i < 3; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < integerException.Min || number > integerException.Max)
            {
                throw integerException;
            }
        }

        Console.WriteLine("Please enter 3 dates between 01.01.1980 and 31.12.2013");
        for (int i = 0; i < 3; i++)
        {
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date < dateException.Min || date > dateException.Max)
            {
                throw dateException;
            }
        }
    }
}
