namespace AllSubsets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = new string[] { "test", "rock", "fun", "stuff" };
            SubsetsGenerator<string> allSubsets = new SubsetsGenerator<string>(input);
            allSubsets.PrintSubsets(2);
        }
    }
}
