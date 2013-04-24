namespace IfStatementsPart1
{
    using System;

    public class PotatoCooker
    {
        public static void Main(string[] args)
        {
            // Create a new potato that by default is good to eat
            // is not peeled and is not cooked
            Potato potato = new Potato();
            
            // Peel the potato
            Peel(potato);
            if (potato.IsGoodToEat && potato.IsPeeled)
            {
                Cook(potato);
            }
        }

        public static void Cook(Potato potatoToCook)
        {
            potatoToCook.IsCooked = true;
            Console.WriteLine("The potato has been cooked!");
        }

        public static void Peel(Potato potatoToPeel)
        {
            potatoToPeel.IsPeeled = true;
        }
    }
}
