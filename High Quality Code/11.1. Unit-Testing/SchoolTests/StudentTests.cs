namespace SchoolTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentSystem;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CreateValidStudentTest()
        {
            Student student = new Student(10000, "Pesho Goshov");
            Assert.IsTrue(student.Id == 10000);
            Assert.IsTrue(student.Name == "Pesho Goshov");
            Assert.IsTrue(student.ToString() == "ID: 10000, Name: Pesho Goshov");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentWithOutOfRangeId()
        {
            Student student = new Student(100000, "Gosho Goshov");
        }
    }
}