using System;
using System.Text;

class BinaryToHex
{
    public static char ConvertHexTokenToBin(string token)
    {
        switch (token)
        {
            case "0000":
                return '0';
            case "0001":
                return '1';
            case "0010":
                return '2';
            case "0011":
                return '3';
            case "0100":
                return '4';
            case "0101":
                return '5';
            case "0110":
                return '6';
            case "0111":
                return '7';
            case "1000":
                return '8';
            case "1001":
                return '9';
            case "1010":
                return 'a';
            case "1011":
                return 'b';
            case "1100":
                return 'c';
            case "1101":
                return 'd';
            case "1110":
                return 'e';
            case "1111":
                return 'f';
            default:
                return '0';
        }
    }

    public static string ConvertHexToBin(string binNumber)
    {
        StringBuilder result = new StringBuilder();
        int remainder = binNumber.Length % 4;

        if (remainder != 0)
        {
            binNumber = binNumber.PadLeft(((binNumber.Length / 4) + 1 )*4, '0');
        }

        for (int i = 0; i < binNumber.Length; i += 4)
        {
            string token = binNumber.Substring(i, 4);
            result.Append(ConvertHexTokenToBin(token));
        }

        return result.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a binary number to convert to hex:");
        string userInput = Console.ReadLine();
        Console.WriteLine("The number in hex = {0}",ConvertHexToBin(userInput));
    }
}