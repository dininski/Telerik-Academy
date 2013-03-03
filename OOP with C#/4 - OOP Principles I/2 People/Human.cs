using System;
using System.Collections.Generic;


namespace PeopleLibrary
{
    public abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}