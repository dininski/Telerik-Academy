namespace Naming_Identifiers
{
    /// <summary>
    /// A human class, which contains a person's name,
    /// age and sex and a method for instantiating the Human.
    /// </summary>
    public class HumanCreator
    {
        /// <summary>
        /// a private enumeration containing the Sex of the human
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// The person is male
            /// </summary>
            MALE,

            /// <summary>
            /// The person is female
            /// </summary>
            FEMALE
        }

        /// <summary>
        /// The program's main entry point
        /// </summary>
        public static void Main()
        {
            HumanCreator humanCreator = new HumanCreator();
            humanCreator.PrintAHuman(15);
            humanCreator.PrintAHuman(16);
        }

        /// <summary>
        /// Prints a human's sex, name and age based on the human's <paramref name="humanAge"/>
        /// </summary>
        /// <param name="humanAge">an integer representing the person's age</param>
        public void PrintAHuman(int humanAge)
        {
            Human newHuman = new Human();
            newHuman.Age = humanAge;
            if (humanAge % 2 == 0)
            {
                newHuman.Name = "The older brother"; // a.k.a. Batkata
                newHuman.Sex = Sex.MALE;
            }
            else
            {
                newHuman.Name = "The female cat"; // a.k.a. Mackata
                newHuman.Sex = Sex.FEMALE;
            }

            System.Console.WriteLine(string.Format("name: {0}, age: {1}, sex: {2}", newHuman.Name, newHuman.Age, newHuman.Sex));
        }

        /// <summary>
        /// A human class, containing a person's age, sex and name
        /// </summary>
        public class Human
        {
            /// <summary>
            /// Gets or sets the person's sex
            /// </summary>
            public Sex Sex { get; set; }

            /// <summary>
            /// Gets or sets the person's name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the person's age
            /// </summary>
            public int Age { get; set; }
        }
    }
}
