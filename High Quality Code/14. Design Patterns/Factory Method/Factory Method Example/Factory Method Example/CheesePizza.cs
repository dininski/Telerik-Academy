namespace Factory_Method_Example
{
    using System;

    public class CheesePizza : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking a cheese pizza!");
        }

        public void Ingridients()
        {
            Console.WriteLine("Cheese, yellow cheese, tomatoes.");
        }
    }
}
