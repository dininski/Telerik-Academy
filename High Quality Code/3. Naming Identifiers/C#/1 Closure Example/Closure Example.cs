namespace Naming_Identifiers
{
    using System;

    /// <summary>
    /// A class printing the value of a boolean variable, 
    /// using a closure for hiding the implementation
    /// </summary>
    public class BooleanPrinter
    {
        /// <summary>
        /// a useless constant
        /// </summary>
        private const int MAX_COUNT = 6;

        /// <summary>
        /// Main entry point of the program
        /// </summary>
        public static void Main()
        {
            BooleanPrinter.ConsoleWriter consoleWriter = new BooleanPrinter.ConsoleWriter();
            consoleWriter.PrintArgument(true);
        }
        
        /// <summary>
        /// ConsoleWriter closure which is available
        /// only to instances of BooleanPrinter
        /// </summary>
        private class ConsoleWriter
        {
            /// <summary>
            /// Prints <paramref name="boolToPrint"/> to the default console.
            /// </summary>
            /// <param name="boolToPrint">a boolean value to print</param>
            public void PrintArgument(bool boolToPrint)
            {
                string boolToPrintAsString = boolToPrint.ToString();
                Console.WriteLine(boolToPrintAsString);
            }
        }
    }
}
