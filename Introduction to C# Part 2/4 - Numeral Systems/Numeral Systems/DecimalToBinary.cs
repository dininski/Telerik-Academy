using System;
using System.Text;

class DecimalToBinary
{
    public static string ConvertToBinary(int number)
    {
        StringBuilder stringHolder = new StringBuilder();
        while (number != 0)
        {
            stringHolder.Append(number % 2);
            number /= 2;
        }

        char[] finalResult = stringHolder.ToString().ToCharArray();
        Array.Reverse(finalResult);
        return new string(finalResult);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a decimal number: ");
        int decimalNumber = int.Parse(Console.ReadLine());
        string binaryNumber = ConvertToBinary(decimalNumber);
        Console.WriteLine(binaryNumber);
    }
}