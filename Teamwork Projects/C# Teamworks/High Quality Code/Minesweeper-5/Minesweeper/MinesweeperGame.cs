namespace Minesweeper
{
    using Minesweeper.InputMethods;
    using Minesweeper.Renderers;

    /// <summary>
    /// A class with the entry point of the program.
    /// </summary>
    public class MinesweeperGame
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            GameEngine ge = new GameEngine(new ConsoleRenderer(), new ConsoleInputMethod());
            ge.StartGame();
        }
    }
}
