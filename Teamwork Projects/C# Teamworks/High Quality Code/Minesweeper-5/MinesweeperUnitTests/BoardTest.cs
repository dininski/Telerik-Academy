namespace MinesweeperUnitTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Common;
    using System.Reflection;

    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The field cannot have a negative side!")]
        public void TestBoardConstructor1_ThrowsExcepsion()
        {
            Board board;
            board = new Board(-1, 10, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The field cannot have a side of 0!")]
        public void TestBoardConstructor2_ThrowsExcepsion()
        {
            Board board;
            board = new Board(10, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The number of mines cannot be larger than the number of fields!")]
        public void TestBoardConstructor3_ThrowsExcepsion()
        {
            Board board;
            board = new Board(10, 5, 51);
        }

        [TestMethod]
        public void TestBoardToString1()
        {
            Board board = new Board(5, 10, 10);
            StringBuilder expected = new StringBuilder();
            expected.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            expected.Append("   _____________________\n");
            expected.Append("0 | ? ? ? ? ? ? ? ? ? ? |\n");
            expected.Append("1 | ? ? ? ? ? ? ? ? ? ? |\n");
            expected.Append("2 | ? ? ? ? ? ? ? ? ? ? |\n");
            expected.Append("3 | ? ? ? ? ? ? ? ? ? ? |\n");
            expected.Append("4 | ? ? ? ? ? ? ? ? ? ? |\n");
            expected.Append("   _____________________\n");

            Assert.AreEqual(expected.ToString(), board.ToString(), "Board string is wrong!");
        }

        [TestMethod]
        public void TestBoardToString2()
        {
            Board board = new Board(1, 1, 1);
            StringBuilder expected = new StringBuilder();
            expected.Append("    0 \n");
            expected.Append("   ___\n");
            expected.Append("0 | ? |\n");
            expected.Append("   ___\n");

            Assert.AreEqual(expected.ToString(), board.ToString(), "Board string is wrong!");
        }

        [TestMethod]
        public void TestBoardToString3()
        {
            int rows = 1;
            int columns = 1;

            Field[,] fixedFields = new Field[rows, columns];
            fixedFields[0, 0] = new Field();
            fixedFields[0, 0].Status = FieldStatus.Opened;
            fixedFields[0, 0].Value = 5;

            Board board = new Board(rows, columns, 1);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 \n");
            str.Append("   ___\n");
            str.Append("0 | 5 |\n");
            str.Append("   ___\n");

            string expected = str.ToString();
            string actual = board.ToString();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestBoardToString4()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                }
            }

            fixedFields[0, 0].Status = FieldStatus.Opened;
            fixedFields[0, 0].Value = 1;
            fixedFields[1, 1].Status = FieldStatus.Opened;
            fixedFields[1, 1].Value = 2;
            fixedFields[2, 2].Status = FieldStatus.Opened;
            fixedFields[2, 2].Value = 3;
            fixedFields[3, 3].Status = FieldStatus.Opened;
            fixedFields[3, 3].Value = 4;
            fixedFields[4, 4].Status = FieldStatus.Opened;
            fixedFields[4, 4].Value = 5;

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            str.Append("   _____________________\n");
            str.Append("0 | 1 ? ? ? ? ? ? ? ? ? |\n");
            str.Append("1 | ? 2 ? ? ? ? ? ? ? ? |\n");
            str.Append("2 | ? ? 3 ? ? ? ? ? ? ? |\n");
            str.Append("3 | ? ? ? 4 ? ? ? ? ? ? |\n");
            str.Append("4 | ? ? ? ? 5 ? ? ? ? ? |\n");
            str.Append("   _____________________\n");

            string expected = str.ToString();
            string actual = board.ToString();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestBoardToString5()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            int counter = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                    fixedFields[i, j].Status = FieldStatus.Opened;
                    fixedFields[i, j].Value = counter;
                    counter++;
                    if (counter == 9)
                    {
                        counter = 1;
                    }
                }
            }

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            str.Append("   _____________________\n");
            str.Append("0 | 1 2 3 4 5 6 7 8 1 2 |\n");
            str.Append("1 | 3 4 5 6 7 8 1 2 3 4 |\n");
            str.Append("2 | 5 6 7 8 1 2 3 4 5 6 |\n");
            str.Append("3 | 7 8 1 2 3 4 5 6 7 8 |\n");
            str.Append("4 | 1 2 3 4 5 6 7 8 1 2 |\n");
            str.Append("   _____________________\n");

            string expected = str.ToString();
            string actual = board.ToString();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestToStringAllFieldsRevealed1()
        {
            Board board = new Board(2, 2, 4);
            StringBuilder result = new StringBuilder();
            result.Append("    0 1 \n");
            result.Append("   _____\n");
            result.Append("0 | * * |\n");
            result.Append("1 | * * |\n");
            result.Append("   _____\n");
            string expected = result.ToString();
            string actual = board.ToStringAllFieldsRevealed();
            Assert.AreEqual(expected, actual, "Wrong count of opened fields!");
        }

        [TestMethod]
        public void TestToStringAllFieldsRevealed2()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            int counter = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                    fixedFields[i, j].Status = FieldStatus.Opened;
                    fixedFields[i, j].Value = counter;
                    counter++;
                    if (counter == 9)
                    {
                        counter = 1;
                    }
                }
            }

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            str.Append("   _____________________\n");
            str.Append("0 | 1 2 3 4 5 6 7 8 1 2 |\n");
            str.Append("1 | 3 4 5 6 7 8 1 2 3 4 |\n");
            str.Append("2 | 5 6 7 8 1 2 3 4 5 6 |\n");
            str.Append("3 | 7 8 1 2 3 4 5 6 7 8 |\n");
            str.Append("4 | 1 2 3 4 5 6 7 8 1 2 |\n");
            str.Append("   _____________________\n");

            string expected = str.ToString();
            string actual = board.ToStringAllFieldsRevealed();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestToStringAllFieldsRevealed3()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                }
            }
            fixedFields[0, 0].Status = FieldStatus.IsAMine;
            fixedFields[4, 9].Status = FieldStatus.IsAMine;

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            str.Append("   _____________________\n");
            str.Append("0 | * 1 0 0 0 0 0 0 0 0 |\n");
            str.Append("1 | 1 1 0 0 0 0 0 0 0 0 |\n");
            str.Append("2 | 0 0 0 0 0 0 0 0 0 0 |\n");
            str.Append("3 | 0 0 0 0 0 0 0 0 1 1 |\n");
            str.Append("4 | 0 0 0 0 0 0 0 0 1 * |\n");
            str.Append("   _____________________\n");

            string expected = str.ToString();
            string actual = board.ToStringAllFieldsRevealed();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestToStringAllFieldsRevealed4()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                    counter++;
                    if (counter == 9)
                    {
                        fixedFields[i, j].Status = FieldStatus.IsAMine;
                        counter = 1;
                    }
                }
            }

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            str.Append("   _____________________\n");
            str.Append("0 | 0 0 0 0 0 1 1 2 * 1 |\n");
            str.Append("1 | 0 0 0 1 1 2 * 2 1 1 |\n");
            str.Append("2 | 0 1 1 2 * 2 1 1 0 0 |\n");
            str.Append("3 | 1 2 * 2 1 1 0 1 1 1 |\n");
            str.Append("4 | * 2 1 1 0 0 0 1 * 1 |\n");
            str.Append("   _____________________\n");

            string expected = str.ToString();
            string actual = board.ToStringAllFieldsRevealed();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestToStringAllFieldsRevealed5()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                }
            }

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            StringBuilder str = new StringBuilder();
            str.Append("    0 1 2 3 4 5 6 7 8 9 \n");
            str.Append("   _____________________\n");
            str.Append("0 | 0 0 0 0 0 0 0 0 0 0 |\n");
            str.Append("1 | 0 0 0 0 0 0 0 0 0 0 |\n");
            str.Append("2 | 0 0 0 0 0 0 0 0 0 0 |\n");
            str.Append("3 | 0 0 0 0 0 0 0 0 0 0 |\n");
            str.Append("4 | 0 0 0 0 0 0 0 0 0 0 |\n");
            str.Append("   _____________________\n");

            string expected = str.ToString();
            string actual = board.ToStringAllFieldsRevealed();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board string is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestCountOpenedFieldsWhenNoOpened()
        {
            Board board = new Board(2, 3, 1);
            int actual = board.CountOpenedFields();
            Assert.AreEqual(0, actual, "Wrong count of opened fields!");
        }

        [TestMethod]
        public void TestCountOpenedFields1()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                    fixedFields[i, j].Status = FieldStatus.Opened;
                }
            }

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            int expected = 50;
            int actual = board.CountOpenedFields();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board opened fields are {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestCountOpenedFields2()
        {
            int rows = 5;
            int columns = 10;

            Field[,] fixedFields = new Field[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    fixedFields[i, j] = new Field();
                }
            }
            
            fixedFields[0, 0].Status = FieldStatus.Opened;

            Board board = new Board(rows, columns, 10);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            int expected = 1;
            int actual = board.CountOpenedFields();

            Assert.AreEqual(
                expected,
                actual,
                string.Format("The board opened fields are {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestOpenFieldWhenMine()
        {
            Board board = new Board(1, 1, 1);

            BoardStatus expected = BoardStatus.SteppedOnAMine;
            BoardStatus actual = board.OpenField(0, 0);

            Assert.AreEqual(
               expected,
               actual,
               string.Format("The BoardStatus is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestOpenFieldWhenOpened()
        {
            int rows = 2;
            int columns = 2;

            Field[,] fixedFields = new Field[rows, columns];

            fixedFields[0, 0] = new Field();
            fixedFields[0, 0].Status = FieldStatus.Opened;

            Board board = new Board(rows, columns, 1);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            BoardStatus expected = BoardStatus.FieldAlreadyOpened;
            BoardStatus actual = board.OpenField(0, 0);

            Assert.AreEqual(
               expected,
               actual,
               string.Format("The BoardStatus is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestOpenFieldWhenClosed()
        {
            int rows = 2;
            int columns = 2;

            Field[,] fixedFields = new Field[rows, columns];

            fixedFields[0, 0] = new Field();
            fixedFields[0, 0].Status = FieldStatus.Closed;
            fixedFields[0, 1] = new Field();
            fixedFields[0, 1].Status = FieldStatus.IsAMine;
            fixedFields[1, 0] = new Field();
            fixedFields[1, 0].Status = FieldStatus.Closed;
            fixedFields[1, 1] = new Field();
            fixedFields[1, 1].Status = FieldStatus.Opened;

            Board board = new Board(rows, columns, 1);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            BoardStatus expected = BoardStatus.FieldSuccessfullyOpened;
            BoardStatus actual = board.OpenField(0, 0);

            Assert.AreEqual(
               expected,
               actual,
               string.Format("The BoardStatus is {0}, but must be {1}!", actual, expected));
        }

        [TestMethod]
        public void TestOpenFieldWhenOpenLastClosed()
        {
            int rows = 2;
            int columns = 2;

            Field[,] fixedFields = new Field[rows, columns];

            fixedFields[0, 0] = new Field();
            fixedFields[0, 0].Status = FieldStatus.Closed;
            fixedFields[0, 1] = new Field();
            fixedFields[0, 1].Status = FieldStatus.IsAMine;
            fixedFields[1, 0] = new Field();
            fixedFields[1, 0].Status = FieldStatus.Opened;
            fixedFields[1, 1] = new Field();
            fixedFields[1, 1].Status = FieldStatus.Opened;

            Board board = new Board(rows, columns, 1);

            Type type = typeof(Board);
            var fieldValue = type.GetField("fields", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(board, fixedFields);

            BoardStatus expected = BoardStatus.AllFieldsAreOpened;
            BoardStatus actual = board.OpenField(0, 0);

            Assert.AreEqual(
               expected,
               actual,
               string.Format("The BoardStatus is {0}, but must be {1}!", actual, expected));
        }
    }
}