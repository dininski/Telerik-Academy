using System;

class BinaryToDecimal
{
    public static int ConvertToDecimal(string binaryNumber)
    {
        char[] binaryArray = binaryNumber.ToCharArray();
        int powerOfTwo = 1;
        int result = 0;
        for (int i = binaryArray.Length -1 ; i >= 0; i--)
        {
            result += (binaryNumber[i] - '0') * powerOfTwo;
            powerOfTwo *= 2;
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a binary number: ");
        string binaryNumber = Console.ReadLine();
        Console.WriteLine(ConvertToDecimal(binaryNumber)); 
    }
}