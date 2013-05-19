namespace Factory_Method_Example
{
    using System;

    public static class PizzaFactory
    {
        public static IPizza MakePizza(string pizzaType)
        {
            switch (pizzaType)
            {
                case "pepperoni":
                    return new PepperoniPizza();
                case "cheese":
                    return new CheesePizza();
                case "vegetable":
                    return new VegetablePizza();
                default:
                    throw new ArgumentException("This pizza place does not offer this type of pizza!");
            }
        }
    }
}
