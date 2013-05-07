namespace StudentSystem.Exceptions
{
    using System;

    public class CourseException : Exception
    {
        public CourseException(string message)
            : base(message)
        {
        }
    }
}
