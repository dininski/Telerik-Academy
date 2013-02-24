using System;

class Stars3D
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        char[, ,] cube = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int d = 0; d < depth; d++)
            {
                char[] tokens = new char[input[d].Length];
                for (int i = 0; i < input[d].Length; i++)
                {
                    tokens[i] = input[d][i];
                }
                for (int w = 0; w < width; w++)
                {
                    char value = tokens[w];
                    cube[w, h, d] = value;
                }
            }
        }

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
        int numberOfStars = 0;
        int[] letters = new int[28];

        for (int w = 1; w < width - 1; w++)
        {
            for (int h = 1; h < height - 1; h++)
            {
                for (int d = 1; d < depth - 1; d++)
                {
                    if (cube[w, h, d] == cube[w + 1, h, d] && cube[w, h, d] == cube[w - 1, h, d] &&
                        cube[w, h, d] == cube[w, h + 1, d] && cube[w, h, d] == cube[w, h - 1, d] &&
                        cube[w, h, d] == cube[w, h, d + 1] && cube[w, h, d] == cube[w, h, d - 1])
                    {
                        letters[(int)(cube[w,h,d]-'A')]++;
                        numberOfStars++;
                    }
                }
            }
        }
        Console.WriteLine(numberOfStars);
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > 0)
            {
                Console.WriteLine("{0} {1}",(char)('A'+i), letters[i]);
            }
        }
    }
}