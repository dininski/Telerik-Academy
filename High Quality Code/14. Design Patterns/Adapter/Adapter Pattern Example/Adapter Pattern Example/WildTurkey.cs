namespace Adapter_Pattern_Example
{
    using System;

    public class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine("Gobble, gobble!");
        }

        public void Fly()
        {
            Console.WriteLine("Grrr, I'm a turkey!");
        }
    }
}
