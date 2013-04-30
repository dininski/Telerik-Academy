namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class, containing information regarding Offsite courses.
    /// </summary>
    public class OffsiteCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class, with a given
        /// <paramref name="courseName"/>.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        public OffsiteCourse(string courseName)
            : this(courseName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class, with a given
        /// <paramref name="courseName"/> and <paramref name="teacherName"/>.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of teacher for this course.</param>
        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class, with a given
        /// <paramref name="courseName"/>, <paramref name="teacherName"/> and <paramref name="students"/>.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of teacher for this course.</param>
        /// <param name="students">A list of students, enrolled for this class.</param>
        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.CourseType = "OffsiteCourse";
            this.Town = null;
        }

        /// <summary>
        /// Gets or sets the town, where the offsite course takes place.
        /// </summary>
        /// <value>Gets or sets the value for the town of the offsite course.</value>
        public string Town { get; set; }

        /// <summary>
        /// Adds the town information to the base string, if
        /// such information exists.
        /// </summary>
        /// <returns>Returns the offsite course information.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
