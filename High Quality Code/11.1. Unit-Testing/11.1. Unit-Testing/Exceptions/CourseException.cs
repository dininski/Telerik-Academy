namespace StudentSystem.Exceptions
{
    using System;

    public class CourseException : Exception
    {
        public CourseException()
            : base()
        {
        }

        public CourseException(string message)
            : base(message)
        {
        }

        public CourseException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
