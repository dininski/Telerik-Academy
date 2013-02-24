using System;
using System.Text;

class DecimalToHex
{
    public static string ConvertToHex(int userInput)
    {
        StringBuilder stringHolder = new StringBuilder();
        int remainder;
        while (userInput != 0)
        {
            remainder = userInput % 16;
            if (remainder < 10)
            {
                stringHolder.Append(remainder);
            }
            else
            {
                stringHolder.Append((char)('A' + remainder - 10));
            }
            userInput /= 16;
        }

        char[] finalResult = stringHolder.ToString().ToCharArray();
        Array.Reverse(finalResult);
        return new string(finalResult);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a decimal number to convert to hexadecimal:");
        int userInput = int.Parse(Console.ReadLine());
        Console.WriteLine(ConvertToHex(userInput)); 
    }
}