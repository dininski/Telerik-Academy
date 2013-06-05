//-----------------------------------------------------------------------
// <copyright file="Board.cs" company="TelerikAcademy">
// All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Minesweeper.Common
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Represents a game board for the minesweeper game.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Number of rows on the boards.
        /// </summary>
        private readonly int rows;

        /// <summary>
        /// Number of columns on the board.
        /// </summary>
        private readonly int columns;

        /// <summary>
        /// Number of mines placed on the board.
        /// </summary>
        private readonly int minesCount;

        /// <summary>
        /// The body of the board.
        /// </summary>
        private readonly Field[,] fields;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board" /> class.
        /// </summary>
        /// <param name="rows">Number of rows on the board.</param>
        /// <param name="columns">Number of columns on the board.</param>
        /// <param name="minesCount">Number of mines on the board.</param>
        public Board(int rows, int columns, int minesCount)
        {
            if (rows < 1)
            {
                throw new ArgumentOutOfRangeException("rows", rows, "Rows cannot not be less then one !!!");
            }

            if (columns < 1)
            {
                throw new ArgumentOutOfRangeException("columns", columns, "Columns cannot not be less then one !!!");
            }

            if (minesCount < 1 || rows * columns < minesCount)
            {
                throw new ArgumentOutOfRangeException(
                    "minesCount", 
                    minesCount,
                    string.Format("The minesCount must be between 1 and {0}!!!", rows * columns));
            }

            this.rows = rows;
            this.columns = columns;
            this.minesCount = minesCount;
            this.fields = new Field[rows, columns];

            for (int row = 0; row < this.rows; row++)
            {
                for (int column = 0; column < this.columns; column++)
                {
                    this.fields[row, column] = new Field();
                }
            } 

            this.SetMines();
        }

        /// <summary>
        /// Prints the game board,  marking the unopened fields with '?'.
        /// </summary>
        /// <returns>Board as string.</returns>
        public override string ToString()
        {
            StringBuilder board = new StringBuilder();
            board.Append(this.ColumnIndexesToString());

            string horizontalLine = new string('_', (this.columns * 2) + 1);
            board.Append("   ").Append(horizontalLine).Append("\n");

            for (int row = 0; row < this.rows; row++)
            {
                board.Append(row).Append(" | ");
                for (int column = 0; column < this.columns; column++)
                {
                    Field currentField = this.fields[row, column];
                    if (currentField.Status == FieldStatus.Opened)
                    {
                        board.Append(this.fields[row, column].Value).Append(" ");
                    }
                    else
                    {
                        board.Append("? ");
                    }
                }

                board.Append("|\n");
            }

            board.Append("   ").Append(horizontalLine).Append("\n");

            return board.ToString();
        }

        /// <summary>
        /// Prints the game board, revealing all the fields. It is used when the game is over.
        /// </summary>
        /// <returns>Board as string with all the fields revealed.</returns>
        public string ToStringAllFieldsRevealed()
        {
            StringBuilder board = new StringBuilder();
            board.Append(this.ColumnIndexesToString());

            string horizontalLine = new string('_', (this.columns * 2) + 1);
            board.Append("   ").Append(horizontalLine).Append("\n");

            for (int row = 0; row < this.rows; row++)
            {
                board.Append(row).Append(" | ");
                for (int column = 0; column < this.columns; column++)
                {
                    Field currentField = this.fields[row, column];
                    if (currentField.Status == FieldStatus.Opened)
                    {
                        board.Append(this.fields[row, column].Value).Append(" ");
                    }
                    else if (currentField.Status == FieldStatus.IsAMine)
                    {
                        board.Append("* ");
                    }
                    else
                    {
                        currentField.Value = this.ScanSurroundingFields(row, column);
                        board.Append(this.fields[row, column].Value).Append(" ");
                    }
                }

                board.Append("|\n");
            }

            board.Append("   ").Append(horizontalLine).Append("\n");

            return board.ToString();
        }

        /// <summary>
        /// Opens a field on the board.
        /// </summary>
        /// <param name="row">Row index of the field.</param>
        /// <param name="column">Column index of the field.</param>
        /// <returns>Status after field opening.</returns>
        public BoardStatus OpenField(int row, int column)
        {
            Field field = this.fields[row, column];
            BoardStatus boardStatus;

            if (field.Status == FieldStatus.IsAMine)
            {
                boardStatus = BoardStatus.SteppedOnAMine;
            }
            else if (field.Status == FieldStatus.Opened)
            {
                boardStatus = BoardStatus.FieldAlreadyOpened;
            }
            else
            {
                field.Value = this.ScanSurroundingFields(row, column);
                field.Status = FieldStatus.Opened;
                if (this.CheckIfWin())
                {
                    boardStatus = BoardStatus.AllFieldsAreOpened;
                }
                else
                {
                    boardStatus = BoardStatus.FieldSuccessfullyOpened;
                }
            }

            return boardStatus;
        }

        /// <summary>
        /// Counts how many fields are opened.
        /// </summary>
        /// <returns>Number of opened fields.</returns>
        public int CountOpenedFields()
        {
            int count = 0;
            for (int row = 0; row < this.rows; row++)
            {
                for (int column = 0; column < this.columns; column++)
                {
                    if (this.fields[row, column].Status == FieldStatus.Opened)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Scans the surrounding fields of certain field in order to find 
        /// the number of the mines placed on the surrounding fields.
        /// </summary>
        /// <param name="row">Row index of the field.</param>
        /// <param name="column">Column index of the field.</param>
        /// <returns>Number of mines placed on the surrounding fields.</returns>
        private int ScanSurroundingFields(int row, int column)
        {
            int mines = 0;
            if ((row > 0) &&
                (column > 0) &&
                (this.fields[row - 1, column - 1].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((row > 0) &&
                (this.fields[row - 1, column].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((row > 0) &&
                (column < this.columns - 1) &&
                (this.fields[row - 1, column + 1].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((column > 0) &&
                (this.fields[row, column - 1].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((column < this.columns - 1) &&
                (this.fields[row, column + 1].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((row < this.rows - 1) &&
                (column > 0) &&
                (this.fields[row + 1, column - 1].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((row < this.rows - 1) &&
                (this.fields[row + 1, column].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            if ((row < this.rows - 1) &&
                (column < this.columns - 1) &&
                (this.fields[row + 1, column + 1].Status == FieldStatus.IsAMine))
            {
                mines++;
            }

            return mines;
        }

        /// <summary>
        /// Converts the header of the game board containing the column's indexes and a horizontal line into string.
        /// </summary>
        /// <returns>The column indexes as string.</returns>
        private string ColumnIndexesToString()
        {
            StringBuilder columnIndexes = new StringBuilder();
            columnIndexes.Append("    ");
            for (int column = 0; column < this.columns; column++)
            {
                columnIndexes.Append(column).Append(" ");
            }

            columnIndexes.Append("\n");

            return columnIndexes.ToString();
        }

        /// <summary>
        /// Places certain number of mines in randomly chosen fields on the board.
        /// </summary>
        private void SetMines()
        {
            for (int mine = 0; mine < this.minesCount; mine++)
            {
                int row = this.GenerateRandomNumber(0, this.rows);
                int column = this.GenerateRandomNumber(0, this.columns);
                if (this.fields[row, column].Status == FieldStatus.IsAMine)
                {
                    mine--;
                }
                else
                {
                    this.fields[row, column].Status = FieldStatus.IsAMine;
                }
            }
        }

        /// <summary>
        /// Generates random number in certain interval.
        /// </summary>
        /// <param name="minValue">Lower limit of the interval.</param>
        /// <param name="maxValue">Upper limit of the interval.</param>
        /// <returns>Generated random number.</returns>
        private int GenerateRandomNumber(int minValue, int maxValue)
        {
            Debug.Assert(minValue < maxValue, "The maxValue must be bigger than minValue!");

            Random random = new Random();
            int number = random.Next(minValue, maxValue);

            Debug.Assert(minValue <= number && number < maxValue, "The number must be between min and max value!");
            return number;
        }

        /// <summary>
        /// Verifies if the game is successfully finished, checking if all the fields without mines placed on them are opened.
        /// </summary>
        /// <returns>
        /// True - if all the mined fields are opened.
        /// False - if there are some mined fields unopened .
        /// </returns>
        private bool CheckIfWin()
        {
            int openedFields = this.CountOpenedFields();

            if ((openedFields + this.minesCount) == (this.rows * this.columns))
            {
                return true;
            }

            return false;
        }
    }
}
