namespace Minesweeper.InputMethods
{
    using System;

    /// <summary>
    /// A class that lets the user control the game using the console.
    /// </summary>
    public class ConsoleInputMethod : IInputMethod
    {
        /// <summary>
        /// Gets the user input.
        /// </summary>
        /// <returns>A string with the user command.</returns>
        public string GetUserInput()
        {
            string userCommand = Console.ReadLine();
            return userCommand;
        }
    }
}
