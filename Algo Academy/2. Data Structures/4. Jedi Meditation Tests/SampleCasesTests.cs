using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jedi_Meditation;

namespace _4.Jedi_Meditation_Tests
{
    [TestClass]
    public class SampleCasesTests
    {
        [TestMethod]
        public void SampleCase_1()
        {
            MeditationSolver ms = new MeditationSolver(3, "m1 k1 p1");
            string expected = "m1 k1 p1";
            Assert.AreEqual(expected, ms.GetMeditationOrder());
        }

        [TestMethod]
        public void SampleCase_2()
        {
            MeditationSolver ms = new MeditationSolver(7, "p4 p2 p3 m1 k2 p1 k1");
            string expected = "m1 k2 k1 p4 p2 p3 p1";
            Assert.AreEqual(expected, ms.GetMeditationOrder());
        }

        [TestMethod]
        public void SampleCase_3()
        {
            MeditationSolver ms = new MeditationSolver(5, "k2 m2 m1 p1 k1");
            string expected = "m2 m1 k2 k1 p1";
            Assert.AreEqual(expected, ms.GetMeditationOrder());
        }
    }
}
