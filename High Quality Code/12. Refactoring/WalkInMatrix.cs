using System;

public class WalkInMatrix
{
    static void Change(ref int dx, ref int dy)
    {
        int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int cd = 0;
        for (int count = 0; count < 8; count++)
        {
            if (dirX[count] == dx && dirY[count] == dy)
            {
                cd = count;
                break;
            }
        }

        if (cd == 7)
        {
            dx = dirX[0];
            dy = dirY[0];
            return;
        }

        dx = dirX[cd + 1];
        dy = dirY[cd + 1];
    }

    static bool Check(int[,] arr, int x, int y)
    {
        int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        for (int i = 0; i < 8; i++)
        {
            if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
            {
                dirX[i] = 0;
            }

            if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
            {
                dirY[i] = 0;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            if (arr[x + dirX[i], y + dirY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    static void FindCell(int[,] arr, out int x, out int y)
    {
        x = 0;
        y = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                if (arr[i, j] == 0)
                {
                    x = i;
                    y = j;
                    return;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int n = 5;
        int[,] matrica = new int[n, n];
        int number = 1;
        int i = 0;
        int j = 0;
        int dx = 1;
        int dy = 1;
        while (true)
        {
            matrica[i, j] = number;

            if (!Check(matrica, i, j))
            {
                break;
            }

            while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0))
            {
                Change(ref dx, ref dy);
            }

            i += dx;
            j += dy;
            number++;
        }

        for (int p = 0; p < n; p++)
        {
            for (int q = 0; q < n; q++)
            {
                Console.Write("{0,3}", matrica[p, q]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        FindCell(matrica, out i, out j);

        if (i != 0 && j != 0)
        {
            dx = 1;
            dy = 1;
            while (true)
            {
                matrica[i, j] = number;
                if (!Check(matrica, i, j))
                {
                    break;
                }

                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0)
                {
                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0))
                    {
                        Change(ref dx, ref dy);
                    }
                }

                i += dx;
                j += dy;
                number++;
            }
        }

        for (int pp = 0; pp < n; pp++)
        {
            for (int qq = 0; qq < n; qq++)
            {
                Console.Write("{0,3}", matrica[pp, qq]);
            }

            Console.WriteLine();
        }
    }
}
