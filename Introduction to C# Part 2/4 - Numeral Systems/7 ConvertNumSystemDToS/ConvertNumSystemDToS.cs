using System;
using System.Text;
using System.Numerics;

class ConvertNumSystemDToS
{

    public static BigInteger ConvertFromBaseNumSystemToDecimal(int initialBase, string number)
    {
        char[] binaryArray = number.ToCharArray();
        int powerOfBase = 1;
        BigInteger result = 0;
        for (int i = binaryArray.Length - 1; i >= 0; i--)
        {
            result += (number[i] - '0') * powerOfBase;
            powerOfBase *= initialBase;
        }
        return result;
    }

    public static string ConvertFromDecToNumSystem(int baseToConvertTo, BigInteger number)
    {
        StringBuilder stringHolder = new StringBuilder();
        int remainder;
        while (number != 0)
        {
            remainder = (int)(number % baseToConvertTo);
            if (remainder < 10)
            {
                stringHolder.Append(remainder);
            }
            else
            {
                stringHolder.Append((char)('A' + remainder - 10));
            }
            number /= baseToConvertTo;
        }
        char[] result = stringHolder.ToString().ToCharArray();
        Array.Reverse(result);

        return new string(result);
    }

    public static string ConvertToNumSystem(int initialBase, int baseToCovertTo, string number)
    {
        BigInteger numberInDecimal = ConvertFromBaseNumSystemToDecimal(initialBase, number);
        Console.WriteLine(numberInDecimal);
        string convertedResult = ConvertFromDecToNumSystem(baseToCovertTo, numberInDecimal);
        Array.Reverse(convertedResult.ToCharArray());
        return convertedResult.ToString() ;
    }
    
    static void Main(string[] args)
    {
        Console.Write("Please enter base of first numeral system (s must be bigger or equal to 2) s = ");
        int baseOfNumSystem = int.Parse(Console.ReadLine());

        Console.Write("Please enter a number in base {0}: ", baseOfNumSystem);
        BigInteger userNumber = BigInteger.Parse(Console.ReadLine());

        Console.Write("Please enter base of the numeral system you want to covert to (d must be smaller or equal to 16) d = ");
        int baseOfConverted = int.Parse(Console.ReadLine());

        Console.WriteLine(ConvertToNumSystem(baseOfNumSystem, baseOfConverted, userNumber.ToString()));

    }
}