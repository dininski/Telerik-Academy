using System;

class HexToDecimal
{
    public static int ConvertToDecimal(string binaryNumber)
    {
        char[] binaryArray = binaryNumber.ToUpper().ToCharArray();
        int powerOfSixteen = 1;
        int currentNumber;
        int result = 0;
        for (int i = binaryArray.Length - 1; i >= 0; i--)
        {
            currentNumber = binaryArray[i] - '0';
            if (currentNumber < 10 && currentNumber > 0)
            {
                result += (currentNumber) * powerOfSixteen;
            }
            else
            {
                result += (binaryArray[i] - 'A' + 10) * powerOfSixteen ;
            }
            powerOfSixteen *= 16;
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a hexadecimal number: ");
        string hexNumber = Console.ReadLine();
        Console.WriteLine(ConvertToDecimal(hexNumber));
    }
}