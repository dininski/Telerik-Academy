namespace StudentSystem.Exceptions
{
    using System;

    public class CourseEmptyException : Exception
    {
        public CourseEmptyException()
            : base()
        {
        }

        public CourseEmptyException(string message)
            : base(message)
        {
        }

        public CourseEmptyException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
