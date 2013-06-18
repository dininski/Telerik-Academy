namespace AllSubsets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = new string[] { "test", "rock", "fun" };
            SubsetsGenerator<string> allSubsets = new SubsetsGenerator<string>(input);
            allSubsets.PrintSubsets(2);
        }
    }
}
