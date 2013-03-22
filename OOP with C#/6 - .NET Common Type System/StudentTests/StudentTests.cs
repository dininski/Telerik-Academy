using System;
using School;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentTests
{
    //TODO Implement Student Tests
    [TestClass]
    public class StudentTests
    {

        [TestMethod]
        public void StudentCloneTest()
        {
            Student studentOne = new Student();
            studentOne.FirstName = "Ivan";
            studentOne.MiddleName = "Petrov";
            studentOne.LastName = "Ivanov";
            studentOne.Address = "Dolno Uino";
            studentOne.Course = "C# OOP";

            Student studentOneClone = (Student)studentOne.Clone();
            Assert.IsTrue(studentOne.Equals(studentOneClone));
            
        }

        [TestMethod]
        public void DifferentStudentsTest()
        {
            Student studentOne = new Student();
            Student studentTwo = new Student();
            studentOne.FirstName = "Georgi";
            studentTwo.FirstName = "Petko";
            Assert.IsTrue(studentOne != studentTwo);
        }
    }
}