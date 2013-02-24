using System;
using System.Collections;
using System.Numerics;


class PrimeNumbersSieveOfEratosthenes
{
    static void Main()
    {

        int maxNum = 10000000;

        BitArray primeNumbers = new BitArray(maxNum, true);

        for (int i = 2; i < Math.Sqrt(maxNum); i++)
        {
            if (primeNumbers[i] == true)
            {
                for (int j = i * i; j < maxNum; )
                {
                    primeNumbers[j] = false;
                    j += i;
                }
            }
        }

        for (int i = 0; i < primeNumbers.Count; i++)
        {
            if (primeNumbers[i] == true)
            {
                Console.Write("{0} ",i);
            }
        }
    }
}
