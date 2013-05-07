namespace SchoolTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentSystem;
    using StudentSystem.Exceptions;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseWithOneStudentTest()
        {
            Student ivan = new Student(10000, "Ivan Ivanov");
            Course sampleCourse = new Course("Javascript");
            sampleCourse.AddStudent(ivan);
            Student[] enrolledStudents = sampleCourse.GetStudents();
            Assert.IsTrue(sampleCourse.CourseName == "Javascript");
            Assert.IsTrue(enrolledStudents.Length == 1);
            Assert.IsTrue(enrolledStudents[0] == ivan);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException))]
        public void AddStudentToFullCourseTest()
        {
            Course sampleCourse = new Course("Javascript");
            for (int i = 0; i < 31; i++)
            {
                sampleCourse.AddStudent(new Student(10000 + i, "Ivan Ivanov"));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentToCourseTwiceTest()
        {
            Course sampleCourse = new Course("Javascript");
            Student ivan = new Student(10000, "Ivan Ivanov");
            sampleCourse.AddStudent(ivan);
            sampleCourse.AddStudent(ivan);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException))]
        public void RemoveFromEmptyCourse()
        {
            Student ivan = new Student(10000, "Ivan Ivanov");
            Course emptyCourse = new Course("Empty course");
            emptyCourse.RemoveStudent(ivan);
        }

        [TestMethod]
        public void RemoveStudentFromCourseTest()
        {
            Student ivan = new Student(10000, "Ivan Ivanov");
            Course sampleCourse = new Course("Javascript");
            sampleCourse.AddStudent(ivan);
            Student[] enrolledStudents = sampleCourse.GetStudents();
            Assert.IsTrue(enrolledStudents.Length == 1);
            sampleCourse.RemoveStudent(ivan);
            Student[] enrolledStudentsWithoutStudent = sampleCourse.GetStudents();
            Assert.IsTrue(enrolledStudentsWithoutStudent.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStudentThatIsNotEnrolledTest()
        {
            Student ivan = new Student(10000, "Ivan Ivanov");
            Student pesho = new Student(10001, "Pesho Peshov");
            Course sampleCourse = new Course("Javascript");
            sampleCourse.AddStudent(ivan);
            sampleCourse.RemoveStudent(pesho);
        }

        [TestMethod]
        public void DisplayEnrolledStudents()
        {
            Student ivan = new Student(10000, "Ivan Ivanov");
            Course sampleCourse = new Course("Javascript");
            sampleCourse.AddStudent(ivan);
            string courseString = sampleCourse.ToString();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Course name: Javascript");
            sb.AppendLine("ID: 10000, Name: Ivan Ivanov");
            string expectedString = sb.ToString();

            Assert.AreEqual(expectedString, courseString);
        }
    }
}