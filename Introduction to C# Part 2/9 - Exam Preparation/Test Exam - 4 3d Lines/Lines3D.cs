using System;

class Lines3D
{
    static int[] maxLength = new int[] { -1, 0 };
    /*  maxLength[0] = -1; //longest line is this long
        maxLength[1] = 0; //times we find the longest line
     */

    //TODO - some diagonals are missing!!!
    static int lineLength = 1;
    static char[, ,] cube;

    public static void CheckLengths()
    {
        if (maxLength[0] < lineLength && lineLength != 1)
        {
            maxLength[0] = lineLength;
            maxLength[1] = 1;
        }
        else if (maxLength[0] == lineLength)
        {
            maxLength[1]++;
        }
        lineLength = 1;
    }

    public static void CheckSides(int width, int height, int depth)
    {

        for (int i = 1; i < cube.GetLength(0) - width; i++)
        {
            if (cube[width, height, depth] == cube[width + i, height, depth])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }

        CheckLengths();

        for (int i = 1; i < cube.GetLength(1) - height; i++)
        {
            if (cube[width, height, depth] == cube[width, height + i, depth])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }

        CheckLengths();

        for (int i = 1; i < cube.GetLength(2) - depth; i++)
        {
            if (cube[width, height, depth] == cube[width, height, depth + i])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }

        CheckLengths();

        for (int i = 1, j = 1; i < cube.GetLength(1) - height && j < cube.GetLength(0) - width; i++, j++)
        {
            if (cube[width, height, depth] == cube[width + j, height + i, depth])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }

        CheckLengths();

        for (int i = 1, j = 1; i < cube.GetLength(2) - depth && j < cube.GetLength(0) - width; i++, j++)
        {
            if (cube[width, height, depth] == cube[width + j, height, depth + i])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }

        CheckLengths();

        for (int i = 1, j = 1; i < cube.GetLength(1) - height && j < cube.GetLength(2) - depth; i++, j++)
        {
            if (cube[width, height, depth] == cube[width, height + i, depth + j])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }

        CheckLengths();

        for (int i = 1, j = 1, k = 1; i < cube.GetLength(1) - height && j < cube.GetLength(2) - depth && k < cube.GetLength(0) - width; i++, j++, k++)
        {
            if (cube[width, height, depth] == cube[width + k, height + i, depth + j])
            {
                lineLength++;
            }
            else
            {
                break;
            }
        }
        CheckLengths();


        //for (int i = 1, j = 1; i < height - cube.GetLength(1) && j < width - cube.GetLength(0); i++, j++)
        //{
        //    if (cube[width, height, depth] == cube[width - j, height - i, depth])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}

        //CheckLengths();

        //for (int i = 1, j = 1; i < depth - cube.GetLength(2) && j < width - cube.GetLength(0); i++, j++)
        //{
        //    if (cube[width, height, depth] == cube[width - j, height, depth - i])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}

        //CheckLengths();

        //for (int i = 1, j = 1; i < height - cube.GetLength(1) && j < depth - cube.GetLength(2); i++, j++)
        //{
        //    if (cube[width, height, depth] == cube[width, height - i, depth - j])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}

        //CheckLengths();

        //for (int i = 1, j = 1, k = 1; i < height - cube.GetLength(1) && j < depth - cube.GetLength(2) && k < width - cube.GetLength(0); i++, j++, k++)
        //{
        //    if (cube[width, height, depth] == cube[width - k, height - i, depth - j])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        //CheckLengths();

        ////+w -h

        //for (int i = 1, j = 1, k = 1; i < cube.GetLength(1) - height && j < depth - cube.GetLength(2) && k < cube.GetLength(0) - width; i++, j++, k++)
        //{
        //    if (cube[width, height, depth] == cube[width + k, height + i, depth - j])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        //CheckLengths();

        //for (int i = 1, j = 1, k = 1; i < height - cube.GetLength(1) && j < depth - cube.GetLength(2) && k < cube.GetLength(0) - width; i++, j++, k++)
        //{
        //    if (cube[width, height, depth] == cube[width + k, height - i, depth - j])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        //CheckLengths();

        //for (int i = 1, j = 1, k = 1; i < cube.GetLength(1) - height && j < depth - cube.GetLength(2) && k < width - cube.GetLength(0); i++, j++, k++)
        //{
        //    if (cube[width, height, depth] == cube[width - k, height + i, depth - j])
        //    {
        //        lineLength++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        //CheckLengths();

    }

    static void Main()
    {
        //need to check three diagonals

        string[] dimensions = Console.ReadLine().Split();
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);

        cube = new char[width, height, depth];



        for (int h = 0; h < height; h++)
        {
            string[] segment = Console.ReadLine().Split();
            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    char value = segment[d][w];
                    cube[w, h, d] = value;
                }
            }
        }

        for (int h = 0; h < height; h++)
        {
            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    CheckSides(w, h, d);
                }
            }
        }

        if (maxLength[0] != -1)
        {
            Console.WriteLine("{0} {1}", maxLength[0], maxLength[1]);
        }
        else
        {
            Console.WriteLine(-1);
        }

    }
}