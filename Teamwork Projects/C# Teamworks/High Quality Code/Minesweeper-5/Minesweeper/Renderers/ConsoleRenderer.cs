namespace Minesweeper.Renderers
{
    using System;
    using Minesweeper.Common;

    /// <summary>
    /// A renderer that uses the console to display the game.
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Draws the game board on the console.
        /// </summary>
        /// <param name="board">The board to draw.</param>
        public void DrawBoard(Board board)
        {
            Console.Write(board.ToString());
        }

        /// <summary>
        /// Displays the message on the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays the error on the console.
        /// </summary>
        /// <param name="error">The error to display.</param>
        public void DisplayError(string error)
        {
            Console.WriteLine(error);
        }
    }
}
