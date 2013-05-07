namespace StudentSystem.Exceptions
{
    using System;

    public class SchoolException : Exception
    {
        public SchoolException(string message)
            : base(message)
        {
        }
    }
}
