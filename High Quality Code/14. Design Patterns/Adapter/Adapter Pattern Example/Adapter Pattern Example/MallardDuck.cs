namespace Adapter_Pattern_Example
{
    using System;

    public class MallardDuck : IDuck
    {
        public void Quack()
        {
            Console.WriteLine("Quack");
        }

        public void Fly()
        {
            Console.WriteLine("Wheeee! I'm a flying mallard!");
        }
    }
}
