namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// An abstract class that contains information regarding
    /// school courses.
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class by given
        /// <paramref name="courseName"/>
        /// </summary>
        /// <param name="courseName">The course name.</param>
        public Course(string courseName)
            : this(courseName, null, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class by given
        /// <paramref name="courseName"/> and <paramref name="teacherName"/>.
        /// </summary>
        /// <param name="courseName">The course name.</param>
        /// <param name="teacherName">The teacher name.</param>
        public Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class by given
        /// <paramref name="courseName"/>, <paramref name="teacherName"/> and 
        /// <paramref name="students"/>.
        /// </summary>
        /// <param name="courseName">The course name.</param>
        /// <param name="teacherName">The teacher name.</param>
        /// <param name="students">A list of students.</param>
        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>Gets or sets the value for the name of the course.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the teacher for this course.
        /// </summary>
        /// <value>Gets or sets the value for the teacher of the course.</value>
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or sets the students that are enrolled for this course.
        /// </summary>
        /// <value>Gets or sets the value for the students, enrolled in the course.</value>
        public IList<string> Students { get; set; }

        /// <summary>
        /// Gets or sets the CourseType.
        /// </summary>
        /// <value>Gets or sets the value for the type of the course.</value>
        protected string CourseType { get; set; }

        /// <summary>
        /// Provides a string, containing all the information regarding the course.
        /// </summary>
        /// <returns>Returns a string, containing all the information regarding the course.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.CourseType);
            result.Append(" { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            // TODO: resolve this:
            // result.Append(" }");
            return result.ToString();
        }

        /// <summary>
        /// A method for converting the list of enrolled students to a string.
        /// </summary>
        /// <returns>Returns a string with all the enrolled students.</returns>
        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
