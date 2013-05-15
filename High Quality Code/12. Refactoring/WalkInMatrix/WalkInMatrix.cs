namespace RotatingWalkInMatrix
{
    using System;

    public class WalkInMatrix
    {
        private static readonly int[,] directions = { { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, 1 } };

        public static int[,] ChangeDirection(int currentXDirection, int currentYDirection)
        {
            int[,] nextDirection = new int[1, 2];
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

        public static bool HasMoreMoves(int[,] board, int xPosition, int yPosition)
        {
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int nextXInDirection = xPosition + directions[i, 0];
                int nextYDirection = yPosition + directions[i, 1];

                if ((nextXInDirection < board.GetLength(0) && nextXInDirection >= 0) &&
                   (nextYDirection < board.GetLength(1) && nextYDirection >= 0))
                {
                    if (board[nextXInDirection, nextYDirection] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static int[,] NextAvailableCell(int[,] board)
        {
            int[,] nextAvailable = { { 0, 0 } };
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i, j] == 0)
                    {
                        nextAvailable[0, 0] = i;
                        nextAvailable[0, 1] = j;
                        return nextAvailable;
                    }
                }
            }

            return nextAvailable;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter matrix size:");
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix;
            matrix = GenerateRotatingWalkMatrix(matrixSize);
            PrintMatrix(matrix);
        }

        public static int[,] GenerateRotatingWalkMatrix(int sizeOfMatrix)
        {
            int matrixSide = sizeOfMatrix;
            int[,] matrix = new int[matrixSide, matrixSide];
            int[,] nextFreeBlock = { { 0, 0 } };
            int[,] movementDirection = { { 1, 1 } };
            int number = 1;
            do
            {
                matrix[nextFreeBlock[0, 0], nextFreeBlock[0, 1]] = number;

                if (HasMoreMoves(matrix, nextFreeBlock[0, 0], nextFreeBlock[0, 1]))
                {
                    while (nextFreeBlock[0, 0] + movementDirection[0, 0] >= matrixSide || nextFreeBlock[0, 0] + movementDirection[0, 0] < 0
                                       || nextFreeBlock[0, 1] + movementDirection[0, 1] >= matrixSide || nextFreeBlock[0, 1] + movementDirection[0, 1] < 0
                                       || matrix[nextFreeBlock[0, 0] + movementDirection[0, 0], nextFreeBlock[0, 1] + movementDirection[0, 1]] != 0)
                    {
                        movementDirection = ChangeDirection(movementDirection[0, 0], movementDirection[0, 1]);
                    }

                    nextFreeBlock[0, 0] += movementDirection[0, 0];
                    nextFreeBlock[0, 1] += movementDirection[0, 1];
                    number++;
                }
                else
                {
                    nextFreeBlock = NextAvailableCell(matrix);
                    movementDirection[0, 0] = directions[0, 0];
                    movementDirection[0, 1] = directions[0, 1];
                    number++;
                }
            } while (number <= matrixSide * matrixSide);

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    Console.Write("{0,4}", matrix[col, row]);
                }
                Console.WriteLine();
            }
        }
    }
}
