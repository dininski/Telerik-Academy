namespace Minesweeper.CommandExecutors
{
    /// <summary>
    /// An interface that provides the base commands used by the game engine.
    /// </summary>
    public interface IGameCommandExecutor
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        void Start();

        /// <summary>
        /// Processes the user input. If the user has entered a row and a column updates
        /// the chosenRow and chosenField. If the user has entered a command updates the
        /// command.
        /// </summary>
        /// <param name="chosenRow">The entered row.</param>
        /// <param name="chosenColumn">The entered column.</param>
        /// <param name="command">The entered command.</param>
        void ProcessUserInput(ref int chosenRow, ref int chosenColumn, ref string command);

        /// <summary>
        /// Displays an error message if the user has entered invalid input.
        /// </summary>
        void DisplayErrorInvalidInput();

        /// <summary>
        /// Checks if there is a mine on the specified coordinates.
        /// </summary>
        /// <param name="chosenRow">The chosen row.</param>
        /// <param name="chosenColumn">The chosen column.</param>
        void CheckCoordinates(int chosenRow, int chosenColumn);

        /// <summary>
        /// Displays the top scores.
        /// </summary>
        void DisplayTopScores();

        /// <summary>
        /// Restarts the game.
        /// </summary>
        void RestartGame();

        /// <summary>
        /// Ends the game with a <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to end game.</param>
        void EndGame(string message);

        /// <summary>
        /// Exits the game.
        /// </summary>
        void ExitGame();
    }
}
