namespace MinesweeperUnitTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Common;
    
    [TestClass]
    public class HighScoresTests
    {        
        [TestMethod]
        public void TestIsHighScore()
        {
            HighScores higScoresList = new HighScores(2);
            bool actual = higScoresList.IsHighScore(12);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsHighScoreWithFullScoreList1()
        {
            HighScores higScoresList = new HighScores(2);
            higScoresList.AddTopScore(new Player("a", 10));
            higScoresList.AddTopScore(new Player("b", 2));           
            bool actual = higScoresList.IsHighScore(12);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsHighScoreWithFullScoreList2()
        {
            HighScores higScoresList = new HighScores(2);
            higScoresList.AddTopScore(new Player("a", 10));
            higScoresList.AddTopScore(new Player("b", 2));           
            bool actual = higScoresList.IsHighScore(1);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDisplayTopScores1()
        {
            HighScores higScoresList = new HighScores(3);
            higScoresList.AddTopScore(new Player("e", 17));
            higScoresList.AddTopScore(new Player("e", 0));
            StringBuilder result = new StringBuilder();            
            result.AppendLine("1. e --> 17");
            result.AppendLine("2. e --> 0");            
            string expected = result.ToString();
            string actual = higScoresList.GetTopScores();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDisplayTopScores2()
        {
            HighScores higScoresList = new HighScores(3);
            higScoresList.AddTopScore(new Player("a", 1));
            higScoresList.AddTopScore(new Player("b", 12));
            higScoresList.AddTopScore(new Player("c", 102));
            higScoresList.AddTopScore(new Player("b", 19));
            StringBuilder result = new StringBuilder();            
            result.Append("1. c --> 102\r\n");
            result.Append("2. b --> 19\r\n");
            result.Append("3. b --> 12\r\n");
            string expected = result.ToString();
            string actual = higScoresList.GetTopScores();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProcessScoreWithNegativeScore()
        {
            HighScores higScoresList = new HighScores(2);
            higScoresList.AddTopScore(new Player("a", 10));
            higScoresList.AddTopScore(new Player("b", 2));
            higScoresList.ProcessScore("mimi", -15);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddScoreNullValue()
        {
            HighScores higScoresList = new HighScores(2);
            higScoresList.AddTopScore(null);
        }

        [TestMethod]       
        public void TestProcessScore()
        {
            HighScores higScoresList = new HighScores(2);
            higScoresList.AddTopScore(new Player("a", 10));
            higScoresList.AddTopScore(new Player("b", 2));
            higScoresList.ProcessScore("mimi", 15);
            StringBuilder result = new StringBuilder();
            result.Append("1. mimi --> 15\r\n");
            result.Append("2. a --> 10\r\n");          
            string expected = result.ToString();
            string actual = higScoresList.GetTopScores();
            Assert.AreEqual(expected, actual);
        }
    }
}
