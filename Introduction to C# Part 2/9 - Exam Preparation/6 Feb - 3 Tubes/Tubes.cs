using System;
using System.Numerics;

class Tubes
{
    //TODO - find acceptable, needs to find maximum
    public static BigInteger BinarySearch(BigInteger bottomLimit, BigInteger topLimit, BigInteger[] pipes, int numberOfSegments)
    {
        var currentTry = (bottomLimit + topLimit) / 2;
        var currentSegments = 0;
        for (int i = 0; i < pipes.Length; i++)
        {
            currentSegments += (int)(pipes[i] / currentTry);
        }
        if (bottomLimit > topLimit)
        {
            return -1;
        }
        if (currentSegments > numberOfSegments)
        {
            return BinarySearch(currentTry, topLimit, pipes, numberOfSegments);
        }
        else if (currentSegments < numberOfSegments)
        {
            return BinarySearch(bottomLimit, currentTry, pipes, numberOfSegments);
        }
        else if (currentSegments == numberOfSegments)
        {
            Console.WriteLine(topLimit);
            Console.WriteLine(bottomLimit);
            return currentTry;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        int inputPipes = int.Parse(Console.ReadLine());
        int numberOfSegments = int.Parse(Console.ReadLine());
        BigInteger[] pipes = new BigInteger[inputPipes];
        BigInteger bottomLimit = 1;
        BigInteger topLimit = -1;
        for (int i = 0; i < inputPipes; i++)
        {
            pipes[i] = BigInteger.Parse(Console.ReadLine());
            if (pipes[i] > topLimit)
            {
                topLimit = pipes[i];
            }
        }
        Console.WriteLine(BinarySearch(bottomLimit, topLimit, pipes, numberOfSegments));
    }
}
