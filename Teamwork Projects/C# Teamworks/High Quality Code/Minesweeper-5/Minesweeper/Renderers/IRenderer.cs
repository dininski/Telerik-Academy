namespace Minesweeper.Renderers
{
    using Minesweeper.Common;
  
    /// <summary>
    /// A renderer with methods to display the game board, a game message
    /// and an error message.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Draws the board.
        /// </summary>
        /// <param name="board">The board.</param>
        void DrawBoard(Board board);

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void DisplayMessage(string message);

        /// <summary>
        /// Displays the error message.
        /// </summary>
        /// <param name="error">The error message.</param>
        void DisplayError(string error);
    }
}
