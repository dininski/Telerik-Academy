using System;
using System.Text;

class ReverseTheDigits
{
    public static string ReverseDigits(string number)
    {
        StringBuilder result = new StringBuilder();
        if (number[0] == '-')
        {
            result.Append("-");
            for (int i = number.Length - 1; i > 0; i--)
            {
                result.Append(number[i]);
            }
        }
        else
        {
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result.Append(number[i]);
            }
        }

        return result.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter an int digit to reverse: ");
        string userEnteredNumber = Console.ReadLine();
        Console.WriteLine("The reversed number {0} is {1}", userEnteredNumber, ReverseDigits(userEnteredNumber));
    }
}