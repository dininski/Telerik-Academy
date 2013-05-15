using System;

namespace WalkInMatrix
{
    public class WalkInMatrix
    {
        private static readonly int[,] directions = { { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, 1 } };

        static int[,] ChangeDirection(int currentXDirection, int currentYDirection)
        {
            int[,] nextDirection = new int[2, 2];
            nextDirection[0, 0] = currentXDirection;
            nextDirection[0, 1] = currentYDirection;
            int currentDirectionIndex = 0;
            for (int count = 0; count < 8; count++)
            {
                if (directions[count, 0] == nextDirection[0, 0] && directions[count, 1] == nextDirection[0, 1])
                {
                    currentDirectionIndex = count;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                nextDirection[0, 0] = directions[0, 0];
                nextDirection[0, 1] = directions[0, 1];
            }
            else
            {
                nextDirection[0, 0] = directions[currentDirectionIndex + 1, 0];
                nextDirection[0, 1] = directions[currentDirectionIndex + 1, 1];
            }
            return nextDirection;
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

        static void FindNextAvailableCell(int[,] arr, out int x, out int y)
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
            int[,] matrica;
            matrica = GenerateRotatingWalkMatrix(n);
            PrintMatrix(matrica);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    Console.Write("{0,3}", matrix[col, row]);
                }

                Console.WriteLine();
            }
        }

        public static int[,] GenerateRotatingWalkMatrix(int sizeOfMatrix)
        {
            int n = sizeOfMatrix;
            int[,] matrix = new int[n, n];
            int[,] nextFreeBlock = { { 0, 0 } };
            int[,] movementDirection = { { 1, 1 } };
            int number = 1;
            while (true)
            {
                matrix[nextFreeBlock[0, 0], nextFreeBlock[0, 1]] = number;

                if (!Check(matrix, nextFreeBlock[0, 0], nextFreeBlock[0, 1]))
                {
                    break;
                }

                while ((nextFreeBlock[0, 0] + movementDirection[0, 0] >= n || nextFreeBlock[0, 0] + movementDirection[0, 0] < 0
                    || nextFreeBlock[0, 1] + movementDirection[0, 1] >= n || nextFreeBlock[0, 1] + movementDirection[0, 1] < 0
                    || matrix[nextFreeBlock[0, 0] + movementDirection[0, 0], nextFreeBlock[0, 1] + movementDirection[0, 1]] != 0))
                {
                    movementDirection = ChangeDirection(movementDirection[0, 0], movementDirection[0, 1]);
                }

                nextFreeBlock[0, 0] += movementDirection[0, 0];
                nextFreeBlock[0, 1] += movementDirection[0, 1];
                number++;
            }

            number++;
            FindNextAvailableCell(matrix, out nextFreeBlock[0, 0], out nextFreeBlock[0, 1]);

            if (nextFreeBlock[0, 0] != 0 && nextFreeBlock[0, 1] != 0)
            {
                movementDirection[0, 0] = 1;
                movementDirection[0, 1] = 1;
                while (true)
                {
                    matrix[nextFreeBlock[0, 0], nextFreeBlock[0, 1]] = number;
                    if (!Check(matrix, nextFreeBlock[0, 0], nextFreeBlock[0, 1]))
                    {
                        break;
                    }

                    if (nextFreeBlock[0, 0] + movementDirection[0, 0] >= n || nextFreeBlock[0, 0] + movementDirection[0, 0] < 0 || nextFreeBlock[0, 1] + movementDirection[0, 1] >= n || nextFreeBlock[0, 1] + movementDirection[0, 1] < 0 || matrix[nextFreeBlock[0, 0] + movementDirection[0, 0], nextFreeBlock[0, 1] + movementDirection[0, 1]] != 0)
                    {
                        while ((nextFreeBlock[0, 0] + movementDirection[0, 0] >= n || nextFreeBlock[0, 0] + movementDirection[0, 0] < 0 || nextFreeBlock[0, 1] + movementDirection[0, 1] >= n || nextFreeBlock[0, 1] + movementDirection[0, 1] < 0 || matrix[nextFreeBlock[0, 0] + movementDirection[0, 0], nextFreeBlock[0, 1] + movementDirection[0, 1]] != 0))
                        {
                            movementDirection = ChangeDirection(movementDirection[0, 0], movementDirection[0, 1]);
                        }
                    }

                    nextFreeBlock[0, 0] += movementDirection[0, 0];
                    nextFreeBlock[0, 1] += movementDirection[0, 1];
                    number++;
                }
            }

            return matrix;
        }
    }
}
