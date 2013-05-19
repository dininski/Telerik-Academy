namespace Factory_Method_Example
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VegetablePizza : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking a vegetable pizza!");
        }

        public void Ingridients()
        {
            Console.WriteLine("Peppers, onions, tomatoes.");
        }
    }
}
