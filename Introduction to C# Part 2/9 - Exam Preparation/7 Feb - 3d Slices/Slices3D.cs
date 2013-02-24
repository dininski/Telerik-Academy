using System;

class Slices3D
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        int[, ,] cube = new int[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] input = Console.ReadLine().Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] tokens = input[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    int value = int.Parse(tokens[w]);
                    cube[w, h, d] = value;
                }
            }
        }

        int totalsum = 0;
        //for (int w = 0; w < width; w++)
        //{
        //    for (int h = 0; h < height; h++)
        //    {
        //        for (int d = 0; d < depth; d++)
        //        {
        //            Console.Write(cube[w, h, d]);
        //        }
        //        Console.Write(' ');
        //    }
        //    Console.WriteLine();
        //}

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    totalsum += cube[w, h, d];
                }
            }
        }

        int currentSum = 0;
        int counter = 0;

        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cube[w, h, d];
                }
            }
            if (currentSum * 2 == totalsum)
            {
                counter++;
            }
        }

        currentSum = 0;
        for (int h = 0; h < height - 1; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cube[w, h, d];
                }
            }
            if (currentSum * 2 == totalsum)
            {
                counter++;
            }
        }

        currentSum = 0;
        for (int d = 0; d < depth - 1; d++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    currentSum += cube[w, h, d];
                }
            }
            if (currentSum * 2 == totalsum)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);

    }
}