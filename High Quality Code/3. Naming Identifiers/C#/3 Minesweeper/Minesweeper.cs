namespace Naming_Identifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A simple minesweeper game
    /// </summary>
    public class Minesweeper
    {
        /// <summary>
        /// The entry point of the program
        /// </summary>
        public static void Main()
        {
            string command = string.Empty;
            char[,] playingField = GeneratePlayingField();
            char[,] mines = PlaceMines();
            int score = 0;
            bool hasSteppedOnMine = false;
            List<Player> highScores = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool hasStartedNewGame = true;
            const int TOTAL_SAFE_BLOCKS = 35;
            bool hasFoundAllSafeBlocks = false;

            do
            {
                if (hasStartedNewGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawField(playingField);
                    hasStartedNewGame = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= playingField.GetLength(0) && column <= playingField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintHighScores(highScores);
                        break;
                    case "restart":
                        playingField = GeneratePlayingField();
                        mines = PlaceMines();
                        DrawField(playingField);
                        hasSteppedOnMine = false;
                        hasStartedNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                PlayerTurn(playingField, mines, row, column);
                                score++;
                            }

                            if (TOTAL_SAFE_BLOCKS == score)
                            {
                                hasFoundAllSafeBlocks = true;
                            }
                            else
                            {
                                DrawField(playingField);
                            }
                        }
                        else
                        {
                            hasSteppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (hasSteppedOnMine)
                {
                    DrawField(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", score);
                    string nickname = Console.ReadLine();
                    Player currentPlayerScore = new Player(nickname, score);
                    if (highScores.Count < 5)
                    {
                        highScores.Add(currentPlayerScore);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i].Points < currentPlayerScore.Points)
                            {
                                highScores.Insert(i, currentPlayerScore);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }

                    highScores.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    highScores.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    PrintHighScores(highScores);
                    playingField = GeneratePlayingField();
                    mines = PlaceMines();
                    score = 0;
                    hasSteppedOnMine = false;
                    hasStartedNewGame = true;
                }

                if (hasFoundAllSafeBlocks)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string playerName = Console.ReadLine();
                    Player playerPoints = new Player(playerName, score);
                    highScores.Add(playerPoints);
                    PrintHighScores(highScores);
                    playingField = GeneratePlayingField();
                    mines = PlaceMines();
                    score = 0;
                    hasFoundAllSafeBlocks = false;
                    hasStartedNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        /// <summary>
        /// Prints the highScores of the game
        /// </summary>
        /// <param name="highScores">given highScores</param>
        private static void PrintHighScores(List<Player> highScores)
        {
            Console.WriteLine("\nTo4KI:");
            if (highScores.Count > 0)
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, highScores[i].Name, highScores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        /// <summary>
        /// Execute the player turn, by checking if the player has 
        /// stepped on a mine in a minefield
        /// </summary>
        /// <param name="playingField">The current playing field</param>
        /// <param name="mines">The mines in the field</param>
        /// <param name="row">The row of the player guess</param>
        /// <param name="column">The column of the player guess</param>
        private static void PlayerTurn(char[,] playingField, char[,] mines, int row, int column)
        {
            char adjacentMines = GetNumberOfAdjacentMines(mines, row, column);
            mines[row, column] = adjacentMines;
            playingField[row, column] = adjacentMines;
        }

        /// <summary>
        /// Draw the a playing field
        /// </summary>
        /// <param name="field">a player field</param>
        private static void DrawField(char[,] field)
        {
            int boardColsLength = field.GetLength(0);
            int boardRowsLength = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int cols = 0; cols < boardColsLength; cols++)
            {
                Console.Write("{0} | ", cols);
                for (int rows = 0; rows < boardRowsLength; rows++)
                {
                    Console.Write(string.Format("{0} ", field[cols, rows]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        /// <summary>
        /// Create a new char[,] playing field
        /// </summary>
        /// <returns>a blank playing field</returns>
        private static char[,] GeneratePlayingField()
        {
            int boardRows = 5;
            int boardCols = 10;
            char[,] field = new char[boardRows, boardCols];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardCols; col++)
                {
                    field[row, col] = '?';
                }
            }

            return field;
        }

        /// <summary>
        /// Generate a minefield and place mines on random positions
        /// </summary>
        /// <returns>new mineField</returns>
        private static char[,] PlaceMines()
        {
            int boardRows = 5;
            int boardCols = 10;
            char[,] mineField = new char[boardRows, boardCols];

            for (int col = 0; col < boardRows; col++)
            {
                for (int row = 0; row < boardCols; row++)
                {
                    mineField[col, row] = '-';
                }
            }

            List<int> minesWithPositions = new List<int>();
            while (minesWithPositions.Count < 15)
            {
                Random random = new Random();
                int minePosition = random.Next(50);
                if (!minesWithPositions.Contains(minePosition))
                {
                    minesWithPositions.Add(minePosition);
                }
            }

            foreach (int minePosition in minesWithPositions)
            {
                int mineColumn = minePosition / boardCols;
                int mineRow = minePosition % boardCols;
                if (mineRow == 0 && minePosition != 0)
                {
                    mineColumn--;
                    mineRow = boardCols;
                }
                else
                {
                    mineRow++;
                }

                mineField[mineColumn, mineRow - 1] = '*';
            }

            return mineField;
        }

        /// <summary>
        /// Solves a minefield
        /// </summary>
        /// <param name="mineField">a minefield which will be solved</param>
        private static void SolveMinefield(char[,] mineField)
        {
            int fieldColumnsLength = mineField.GetLength(0);
            int fieldRowsLength = mineField.GetLength(1);

            for (int col = 0; col < fieldColumnsLength; col++)
            {
                for (int row = 0; row < fieldRowsLength; row++)
                {
                    if (mineField[col, row] != '*')
                    {
                        char numberOfAdjacent = GetNumberOfAdjacentMines(mineField, col, row);
                        mineField[col, row] = numberOfAdjacent;
                    }
                }
            }
        }

        /// <summary>
        /// Finds the number of adjacent mines and changes the value
        /// of the playing field
        /// </summary>
        /// <param name="playingField">the playing field which needs to be checked</param>
        /// <param name="row">row of the guess</param>
        /// <param name="col">column of the guess</param>
        /// <returns>number of adjacent mines</returns>
        private static char GetNumberOfAdjacentMines(char[,] playingField, int row, int col)
        {
            int numberOfMines = 0;
            int fieldRowsLength = playingField.GetLength(0);
            int fieldColumnsLength = playingField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playingField[row - 1, col] == '*')
                {
                    numberOfMines++;
                }
            }

            if (row + 1 < fieldRowsLength)
            {
                if (playingField[row + 1, col] == '*')
                {
                    numberOfMines++;
                }
            }

            if (col - 1 >= 0)
            {
                if (playingField[row, col - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if (col + 1 < fieldColumnsLength)
            {
                if (playingField[row, col + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playingField[row - 1, col - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < fieldColumnsLength))
            {
                if (playingField[row - 1, col + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row + 1 < fieldRowsLength) && (col - 1 >= 0))
            {
                if (playingField[row + 1, col - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row + 1 < fieldRowsLength) && (col + 1 < fieldColumnsLength))
            {
                if (playingField[row + 1, col + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            return char.Parse(numberOfMines.ToString());
        }

        /// <summary>
        /// A class which holds the player information
        /// </summary>
        public class Player
        {
            /// <summary>
            /// holds information about the player name
            /// </summary>
            private string name;

            /// <summary>
            /// holds information about the player points
            /// </summary>
            private int points;

            /// <summary>
            /// Initializes a new instance of the <see cref="Player"/> class with
            /// <paramref name="name"/> and <paramref name="points"/>
            /// </summary>
            /// <param name="name">player name</param>
            /// <param name="points">initial player score</param>
            public Player(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            /// <summary>
            /// Gets or sets the player name
            /// </summary>
            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            /// <summary>
            /// Gets or sets the player points
            /// </summary>
            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }
    }
}
