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
            int id = 100000;
            string name = "Gosho Goshov";
            Student student = new Student(id, name);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithNoName()
        {
            int id = 10000;
            string name = string.Empty;
            Student student = new Student(id, name);
            Assert.Fail();
        }
    }
}