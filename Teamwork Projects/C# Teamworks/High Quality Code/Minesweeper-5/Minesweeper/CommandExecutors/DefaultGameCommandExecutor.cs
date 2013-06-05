namespace Minesweeper.CommandExecutors
{
    using System;
    using Minesweeper.Common;
    using Minesweeper.InputMethods;
    using Minesweeper.Renderers;
    
    /// <summary>
    /// A game command executor, that processes commands based on the user
    /// input.
    /// </summary>
    public class DefaultGameCommandExecutor : IGameCommandExecutor
    {
        /// <summary>
        /// The maximum rows in the playing field.
        /// </summary>
        private const int MaxRows = 5;

        /// <summary>
        /// The maximum columns in the playing field.
        /// </summary>
        private const int MaxColumns = 10;

        /// <summary>
        /// The maximum mines in the playing field.
        /// </summary>
        private const int MaxMines = 15;

        /// <summary>
        /// The game renderer that will be used.
        /// </summary>
        private readonly IRenderer gameRenderer;

        /// <summary>
        /// The input method that will be used.
        /// </summary>
        private readonly IInputMethod inputMethod;

        /// <summary>
        /// The high scores for this game.
        /// </summary>
        private readonly HighScores scores;

        /// <summary>
        /// The minefield board.
        /// </summary>
        private Board board;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultGameCommandExecutor" /> class.
        /// </summary>
        /// <param name="renderer">The game renderer.</param>
        /// <param name="inputMethod">The input method.</param>
        /// <param name="scores">The high scores.</param>
        public DefaultGameCommandExecutor(IRenderer renderer, IInputMethod inputMethod, HighScores scores)
        {
            this.scores = scores;
            this.gameRenderer = renderer;
            this.inputMethod = inputMethod;
            this.GenerateNewBoard(MaxRows, MaxColumns, MaxMines);
        }

        /// <summary>
        /// Starts the command executor.
        /// </summary>
        public void Start()
        {
            string command = "restart";
            int chosenRow = 0;
            int chosenColumn = 0;

            while (command != "exit")
            {
                switch (command)
                {
                    case "restart":
                        this.RestartGame();
                        break;
                    case "top":
                        this.DisplayTopScores();
                        break;
                    case "coordinates":
                        this.CheckCoordinates(chosenRow, chosenColumn);
                        break;
                    case "exit":
                        this.ExitGame();
                        return;
                    default:
                        this.DisplayErrorInvalidInput();
                        break;
                }

                this.ProcessUserInput(ref chosenRow, ref chosenColumn, ref command);
            }
        }

        /// <summary>
        /// Processes the user input. If the user has entered a row and a column updates
        /// the chosenRow and chosenField. If the user has entered a command updates the
        /// command.
        /// </summary>
        /// <param name="chosenRow">The entered row.</param>
        /// <param name="chosenColumn">The entered column.</param>
        /// <param name="command">The entered command.</param>
        public void ProcessUserInput(ref int chosenRow, ref int chosenColumn, ref string command)
        {
            this.gameRenderer.DisplayMessage("Enter row and column: ");
            string playerInput = this.inputMethod.GetUserInput();
            if (int.TryParse(playerInput, out chosenRow))
            {
                playerInput = this.inputMethod.GetUserInput();
                if (int.TryParse(playerInput, out chosenColumn))
                {
                    command = "coordinates";
                }
                else
                {
                    command = playerInput;
                }
            }
            else
            {
                command = playerInput;
            }
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void ExitGame()
        {
            this.gameRenderer.DisplayMessage("Good bye!");
        }

        /// <summary>
        /// Displays and error, stating the player has entered invalid input.
        /// </summary>
        public void DisplayErrorInvalidInput()
        {
            this.gameRenderer.DisplayError("Invalid input!");
        }

        /// <summary>
        /// Checks if there is a mine at the specified coordinates.
        /// </summary>
        /// <param name="chosenRow">The chosen row.</param>
        /// <param name="chosenColumn">The chosen column.</param>
        public void CheckCoordinates(int chosenRow, int chosenColumn)
        {
            try
            {
                BoardStatus boardStatus = this.board.OpenField(chosenRow, chosenColumn);
                if (boardStatus == BoardStatus.SteppedOnAMine)
                {
                    int score = this.board.CountOpenedFields();
                    this.EndGame(
                        string.Format(
                        "Booooom! You were killed by a mine. You revealed" + " {0} cells without mines.", score));
                    this.RestartGame();
                }
                else if (boardStatus == BoardStatus.FieldAlreadyOpened)
                {
                    this.gameRenderer.DisplayMessage("That field has already been opened!");
                }
                else if (boardStatus == BoardStatus.AllFieldsAreOpened)
                {
                    this.EndGame("Congratulations! You win!!");
                    this.RestartGame();
                }
                else
                {
                    this.gameRenderer.DrawBoard(this.board);
                }
            }
            catch (IndexOutOfRangeException)
            {
                this.gameRenderer.DisplayError("The row and column entered must be within the playing field!");
            }
        }

        /// <summary>
        /// Displays the top scores.
        /// </summary>
        public void DisplayTopScores()
        {
            this.gameRenderer.DisplayMessage("Scoreboard");
            string topScore = this.scores.GetTopScores();
            this.gameRenderer.DisplayMessage(topScore);
        }

        /// <summary>
        /// Restarts the game.
        /// </summary>
        public void RestartGame()
        {
            this.GenerateNewBoard(MaxRows, MaxColumns, MaxMines);
            this.gameRenderer.DisplayMessage(
                "Welcome to the game “Minesweeper”. " +
                "Try to reveal all cells without mines. " +
                "Use 'top' to view the scoreboard, 'restart' to start a new game" +
                "and 'exit' to quit the game.");

            this.gameRenderer.DrawBoard(this.board);
        }

        /// <summary>
        /// Generates a new board.
        /// </summary>
        /// <param name="maxRows">The maximum rows of the board.</param>
        /// <param name="maxColumns">The maximum columns of the board.</param>
        /// <param name="maxMines">The maximum mines of the board.</param>
        public void GenerateNewBoard(int maxRows, int maxColumns, int maxMines)
        {
            this.board = new Board(maxRows, maxColumns, maxMines);
        }

        /// <summary>
        /// Ends the game with a <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        public void EndGame(string message)
        {
            this.gameRenderer.DisplayMessage(this.board.ToStringAllFieldsRevealed());
            this.gameRenderer.DisplayMessage(message);

            this.gameRenderer.DisplayMessage("Please enter a name:");
            string playerName = this.inputMethod.GetUserInput();
            while (string.IsNullOrEmpty(playerName))
            {
                this.gameRenderer.DisplayMessage("Invalid name. Please enter a name that is not empty:");
                playerName = this.inputMethod.GetUserInput();
            }

            int score = this.board.CountOpenedFields();
            this.scores.ProcessScore(playerName, score);
            this.gameRenderer.DisplayMessage("Scoreboard");
            string topScores = this.scores.GetTopScores();
            this.gameRenderer.DisplayMessage(topScores);
        }
    }
}
