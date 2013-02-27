using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class VersionTestClassTest
    {
        [TestMethod]
        public void VersionTestClassBaseCase()
        {
            VersionTestClass test = new VersionTestClass();
            Console.WriteLine(test.GetVersion());
            Assert.IsTrue(test.GetVersion() == "1.123");
        }
    }
}
