namespace Factory_Method_Example
{
    using System;

    public class PepperoniPizza : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking a pepperoni pizza!");
        }

        public void Ingridients()
        {
            Console.WriteLine("Pepperoni, tomatoes.");
        }
    }
}
