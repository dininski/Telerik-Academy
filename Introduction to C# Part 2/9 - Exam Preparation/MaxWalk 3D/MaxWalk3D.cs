using System;

class MaxWalk3D
{

    public static int StartWalk(int[,,]cube, bool[,,] visited, int startW, int startH, int startD)
    {
        int sum = 0;
        return sum;
    }

    public static bool CanStep(int[,,] cube, int startW, int startH, int startD)
    {
        if (true)
        {
            
        }
        return false;
    }


    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);

        int[,,] cube = new int[width,height,depth];
        bool[, ,] visited = new bool[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] rows = Console.ReadLine().Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] numbers = rows[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    int value = int.Parse(numbers[w]);
                    cube[w, h, d] = value;
                }
            }
        }

        Console.WriteLine(StartWalk(cube, visited, 0, 0, 0));
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
    }
}