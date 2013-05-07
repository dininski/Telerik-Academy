namespace SchoolTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentSystem;
using StudentSystem.Exceptions;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void AddSchoolCourseTest()
        {
            School school = new School();
            Course sampleCourse = new Course("Javascript");
            school.AddCourse(sampleCourse);
            var schoolCourses = school.GetCourses();
            Assert.IsTrue(schoolCourses.Length == 1);
            Assert.AreEqual(sampleCourse, schoolCourses[0]);
        }

        [TestMethod]
        public void RemoveSchoolCourseTest()
        {
            School school = new School();
            Course sampleCourse = new Course("Javascript");
            school.AddCourse(sampleCourse);
            var schoolCourses = school.GetCourses();
            Assert.AreEqual(1, schoolCourses.Length);
            school.RemoveCourse(sampleCourse);
            var schoolCoursesUpdated = school.GetCourses();
            Assert.AreEqual(0, schoolCoursesUpdated.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(SchoolException))]
        public void CourseAlreadyAddedInSchoolTest()
        {
            School school = new School();
            Course sampleCourse = new Course("Javascript");
            school.AddCourse(sampleCourse);
            school.AddCourse(sampleCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCourseToSchool()
        {
            School school = new School();
            school.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(SchoolException))]
        public void RemoveFromEmptyCourseListTest()
        {
            School school = new School();
            Course sampleCourse = new Course("Javascript");
            school.RemoveCourse(sampleCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullCourseTest()
        {
            School school = new School();
            school.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(SchoolException))]
        public void RemoveNonexistingCourseTest()
        {
            School school = new School();
            Course registeredCourse = new Course("Javascript");
            Course notRegisteredCourse = new Course("PHP");
            school.AddCourse(registeredCourse);
            school.RemoveCourse(notRegisteredCourse);
        }
    }
}
