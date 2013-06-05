namespace MinesweeperUnitTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.InputMethods;

    [TestClass]
    public class ConsoleInputMethodTests
    {
        private StringWriter stringWriter;
        private StringReader stringReader;

        [TestInitialize]
        public void InitializeWriterStream()
        {
            this.stringWriter = new StringWriter();
        }

        [TestMethod]
        public void ConsoleInputMethodStringTest1()
        {
            string testString = "test string";
            this.stringReader = new StringReader(testString);

            using (this.stringWriter)
            {
                using (this.stringReader)
                {
                    Console.SetOut(this.stringWriter);
                    Console.SetIn(this.stringReader);
                    ConsoleInputMethod inputMethod = new ConsoleInputMethod();
                    string actual = inputMethod.GetUserInput();
                    string expected = "test string";
                    Assert.AreEqual(expected, actual, "The console reader is not working correctly");
                }
            }
        }

        [TestMethod]
        public void ConsoleInputMethodStringTest2()
        {
            string testString = "1";
            this.stringReader = new StringReader(testString);

            using (this.stringWriter)
            {
                using (this.stringReader)
                {
                    Console.SetOut(this.stringWriter);
                    Console.SetIn(this.stringReader);
                    ConsoleInputMethod controller = new ConsoleInputMethod();
                    string actual = controller.GetUserInput();
                    string expected = "1";
                    Assert.AreEqual(expected, actual, "The console reader is not working correctly");
                }
            }
        }

        [TestMethod]
        public void ConsoleInputMethodStringTest3()
        {
            string testString = "exit";
            this.stringReader = new StringReader(testString);

            using (this.stringWriter)
            {
                using (this.stringReader)
                {
                    Console.SetOut(this.stringWriter);
                    Console.SetIn(this.stringReader);
                    ConsoleInputMethod controller = new ConsoleInputMethod();
                    string actual = controller.GetUserInput();
                    string expected = "exit";
                    Assert.AreEqual(expected, actual, "The console reader is not working correctly");
                }
            }
        }
    }
}
