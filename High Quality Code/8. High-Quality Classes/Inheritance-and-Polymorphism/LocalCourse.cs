namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class, containing information about a local course.
    /// </summary>
    public class LocalCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class by given
        /// <paramref name="courseName"/>.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        public LocalCourse(string courseName)
            : this(courseName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class by given
        /// <paramref name="courseName"/> and <paramref name="teacherName"/>.
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <param name="teacherName">The name of the teacher for this course.</param>
        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class by given
        /// <paramref name="courseName"/>, <paramref name="teacherName"/> and
        /// <paramref name="students"/>
        /// </summary>
        /// <param name="courseName">The name of the course.</param>
        /// <param name="teacherName">The name of the teacher for this course.</param>
        /// <param name="students">The students, that are enrolled for this course.</param>
        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.CourseType = "OffsiteCourse";
            this.Lab = null;
        }

        /// <summary>
        /// Gets or sets the lab, where the local course will take place.
        /// </summary>
        /// <value>Gets or sets the value for the lab of the local course.</value>
        public string Lab { get; set; }

        /// <summary>
        /// Adds the lab information to the base string, if
        /// such information exists.
        /// </summary>
        /// <returns>Returns the local course information.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
