namespace MinesweeperUnitTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.CommandExecutors;
    using Minesweeper.Common;
    using MinesweeperUnitTests.MockClasses;

    [TestClass]
    public class CommandExecutorTests
    {
        private static MockRenderer mockRenderer;
        private static MockInputMethod mockInputMethod;

        [TestInitialize]
        public void InitializeMocks()
        {
            mockRenderer = new MockRenderer();
            mockInputMethod = new MockInputMethod();
        }

        [TestMethod]
        public void TestCmdExecutorExitGame()
        {
            DefaultGameCommandExecutor cmdExecutor = new DefaultGameCommandExecutor(mockRenderer, mockInputMethod, new HighScores(10));
            cmdExecutor.ExitGame();
            string exitMessage = mockRenderer.GetMessage();
            string expectedExitMessage = "Good bye!";
            Assert.AreEqual(expectedExitMessage, exitMessage, "The exit message is incorrect!");
        }

        [TestMethod]
        public void TestCmdExecutorInvalidInput()
        {
            DefaultGameCommandExecutor cmdExecutor = new DefaultGameCommandExecutor(mockRenderer, mockInputMethod, new HighScores(10));
            cmdExecutor.DisplayErrorInvalidInput();
            string errorMessage = mockRenderer.GetError();
            string expectedErrorMessage = "Invalid input!";
            Assert.AreEqual(expectedErrorMessage, errorMessage, "The message when the input is invalid is incorrect!");
        }

        [TestMethod]
        public void TestCmdExecutorRestartGame()
        {
            DefaultGameCommandExecutor cmdExecutor = new DefaultGameCommandExecutor(mockRenderer, mockInputMethod, new HighScores(10));
            cmdExecutor.RestartGame();
            string restartMessage = mockRenderer.GetMessage();
            string expectedRestartMessage = "Welcome to the game “Minesweeper”. " +
                "Try to reveal all cells without mines. " +
                "Use 'top' to view the scoreboard, 'restart' to start a new game" +
                "and 'exit' to quit the game.";
            Assert.AreEqual(expectedRestartMessage, restartMessage, "The message when the input is invalid is incorrect!");
        }

        [TestMethod]
        public void TestCmdExecutorEmptyScores()
        {
            DefaultGameCommandExecutor cmdExecutor = new DefaultGameCommandExecutor(mockRenderer, mockInputMethod, new HighScores(10));
            cmdExecutor.DisplayTopScores();
            string scoreMessage = mockRenderer.GetMessage();
            string expectedScoreMessage = "Scoreboard";
            Assert.AreEqual(expectedScoreMessage, scoreMessage, "The message when the input is invalid is incorrect!");
        }

        [TestMethod]
        public void TestCmdExecutorFiveScores()
        {
            HighScores scores = new HighScores(5);
            scores.ProcessScore("pesho", 100);
            scores.ProcessScore("ivan", 80);
            scores.ProcessScore("gosho", 70);
            scores.ProcessScore("stamat", 60);
            scores.ProcessScore("petkan", 50);
            DefaultGameCommandExecutor cmdExecutor = new DefaultGameCommandExecutor(mockRenderer, mockInputMethod, scores);
            cmdExecutor.DisplayTopScores();
            string scoreMessage = mockRenderer.GetMessage();
            StringBuilder expectedScoreMessage = new StringBuilder();
            expectedScoreMessage.Append("Scoreboard");
            expectedScoreMessage.AppendLine("1. pesho --> 100");
            expectedScoreMessage.AppendLine("2. ivan --> 80");
            expectedScoreMessage.AppendLine("3. gosho --> 70");
            expectedScoreMessage.AppendLine("4. stamat --> 60");
            expectedScoreMessage.AppendLine("5. petkan --> 50");
            Assert.AreEqual(expectedScoreMessage.ToString(), scoreMessage, "The message when the input is invalid is incorrect!");
        }
    }
}
