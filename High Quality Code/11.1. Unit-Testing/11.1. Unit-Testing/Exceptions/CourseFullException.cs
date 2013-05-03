namespace StudentSystem.Exceptions
{
    using System;

    public class CourseFullException : Exception
    {
        public CourseFullException()
            : base()
        {
        }

        public CourseFullException(string message)
            : base(message)
        {
        }

        public CourseFullException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
