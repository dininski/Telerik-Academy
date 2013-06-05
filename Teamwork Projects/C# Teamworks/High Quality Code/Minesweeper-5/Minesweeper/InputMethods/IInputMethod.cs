namespace Minesweeper.InputMethods
{
    /// <summary>
    /// An interface that provides a method to obtain the user input.
    /// </summary>
    public interface IInputMethod
    {
        /// <summary>
        /// Gets the user input.
        /// </summary>
        /// <returns>A string with the user input.</returns>
        string GetUserInput();
    }
}
