using System;
using System.Collections.Generic;

class AddNumberAsArray
{
    public static byte[] AddArrays(byte[] firstNum, byte[] secondNum)
    {
        byte[] result;
        byte sum;
        if (secondNum.Length > firstNum.Length)
        {
            return AddArrays(secondNum, firstNum);
        }

        result = new byte[firstNum.Length + 1];

        for (int i = 0; i < secondNum.Length; i++)
        {
            sum = (byte)(firstNum[i] + secondNum[i] + result[i]);
            if (sum < 10)
            {
                result[i] += sum;
            }
            else
            {
                result[i] = (byte)(sum % 10);
                result[i + 1]++;
            }
        }

        for (int j = secondNum.Length; j < firstNum.Length; j++)
        {
            sum = (byte)(result[j] + firstNum[j]);
            if (sum < 10)
            {
                result[j] += firstNum[j];
            }
            else
            {
                result[j] = (byte)(sum % 10);
                result[j + 1]++;
            }
        }

        if (result[firstNum.Length] == 0)
        {
            Array.Resize(ref result, result.Length - 1);
        }
        return result;
    }

    private static void AddAndPrint(byte[] a, byte[] b)
    {
        byte[] res = AddArrays(a, b);
        for (int i = a.Length - 1; i >= 0; i--)
        {
            Console.Write(a[i]);

        }

        Console.Write(" + ");

        for (int i = b.Length - 1; i >= 0; i--)
        {
            Console.Write(b[i]);

        }

        Console.Write(" = ");

        for (int i = res.Length - 1; i >= 0; i--)
        {
            Console.Write(res[i]);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        byte[] a = { 1, 1, 3, 1, 8 };
        byte[] b = { 2, 2, 7, 9 };

        AddAndPrint(a, b);
        AddAndPrint(new byte[] { 0, 0, 1 }, new byte[] { 0 });
        AddAndPrint(new byte[] { 3, 6, 8, 7, 1, 2, 3, 6, 8 }, new byte[] { 9, 4, 8, 7, 2, 3, 6, 4 });
        AddAndPrint(new byte[] { 3, 1, 5, 8, 5 }, new byte[] { 1, 3, 9, 5, 4 });
        AddAndPrint(new byte[] { 9, 9, 9, 9, 9, 9, 9 }, new byte[] { 2, 1, 2, 5, 8 });
        AddAndPrint(new byte[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new byte[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 });
    }


}