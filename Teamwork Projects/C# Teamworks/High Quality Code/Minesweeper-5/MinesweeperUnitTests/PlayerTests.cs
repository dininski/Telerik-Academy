namespace MinesweeperUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Common;
    
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerTestConstructor()
        {
            Player first = new Player("a", -12);
        }

        [TestMethod]
        public void PlayerTestCompareTo1()
        {
            Player first = new Player("a", 12);
            Player second = new Player("b", 1);
            Assert.AreEqual(-1, first.CompareTo(second), "CompareTo not working correctly");
        }

        [TestMethod]
        public void PlayerTestCompareTo2()
        {
            Player first = new Player("a", 12);
            Player second = new Player("b", 120);
            Assert.AreEqual(1, first.CompareTo(second), "CompareTo not working correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerTestCompareToExpectedException()
        {
            Player player = new Player("a", 12);
            player.CompareTo(12);
        }

        [TestMethod]
        public void PlayerTestToString()
        {
            Player player = new Player("mimi", 123);
            string expected = "mimi --> 123";
            string actual = player.ToString();
            Assert.AreEqual(expected, actual, "ToString not working correctly");
        }

        [TestMethod]
        public void PlayerTestGetName()
        {
            Player player = new Player("gosho", 14);
            Assert.AreEqual("gosho", player.Name, "The player class is not being instantiated as expected!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerTestNullName()
        {
            Player player = new Player(null, 14);
        }
    }
}
