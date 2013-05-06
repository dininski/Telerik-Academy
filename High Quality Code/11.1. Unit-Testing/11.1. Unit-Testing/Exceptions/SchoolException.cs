namespace StudentSystem.Exceptions
{
    using System;

    public class SchoolException : Exception
    {
        public SchoolException()
            : base()
        {
        }

        public SchoolException(string message)
            : base(message)
        {
        }

        public SchoolException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
