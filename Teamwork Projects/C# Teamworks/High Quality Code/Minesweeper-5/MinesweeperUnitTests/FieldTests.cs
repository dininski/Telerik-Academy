namespace MinesweeperUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Common;
    
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void FieldTestInstantiate()
        {
            Field field = new Field();
            field.Status = FieldStatus.Closed;
            field.Value = 8;
            Assert.AreEqual(8, field.Value, "The value has been changed by the field!");
            Assert.AreEqual(FieldStatus.Closed, field.Status, "The FieldStatus enumerations has been changed by the field!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The number of adjacent mines cannot be larger than the number of adjacent fields!")]
        public void FieldTestInvalidValue()
        {
            Field field = new Field();
            field.Status = FieldStatus.Closed;
            field.Value = 10;
        }
    }
}
