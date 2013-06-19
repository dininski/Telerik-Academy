using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Program
    {
        static char[,] field;
        static char[,] solution;
        static char[] xOrO;

        public static void Main(string[] args)
        {
            solution = new char[3, 3];
            field = new char[3, 3];
            xOrO = new char[2];
            xOrO[0] = 'X';
            xOrO[1] = 'O';
            for (int i = 0; i < 3; i++)
            {
                string row = Console.ReadLine();

                for (int el = 0; el < row.Length; el++)
                {
                    field[i, el] = row[el];
                }
            }

            Solve(0, 0, 0, 0);
        }

        static void Solve(int col, int row, int current, int playerMove)
        {
            if (row == 3)
            {
                row = 0;
                col++;
            }

            if (col == 3)
            {
                return;
            }
            else
            {
                for (int i = 3 * col + row; i < 9; i++)
                {
                    if (field[col, row] != '-')
                    {
                        solution[col, row] = field[col, row];
                    }
                    else
                    {
                        solution[col, row] = xOrO[playerMove % 2];
                        playerMove++;
                        Solve(col, row, current, playerMove);
                    }
                }
            }
        }
    }
}
