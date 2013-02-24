using System;

class IntDoubleOrString
{
    static void Main()
    {
        byte userChoice;
        Console.WriteLine("Please enter 1 for integer, 2 for double and 3 for string:");
        userChoice = byte.Parse(Console.ReadLine());
        switch (userChoice)
        {
            case 1:
                Console.WriteLine("enter an integer:");
                int intResult = int.Parse(Console.ReadLine());
                intResult++;
                Console.WriteLine("modified integer = {0}", intResult);
                break;
            case 2:
                Console.WriteLine("enter a double value:");
                double doubleResult = double.Parse(Console.ReadLine());
                doubleResult++;
                Console.WriteLine("modified double = {0}", doubleResult);
                break;
            case 3:
                Console.WriteLine("enter a string:");
                string stringResult = Console.ReadLine();
                stringResult += "*";
                Console.WriteLine("modified string = {0}", stringResult);
                break;
            default:
                Console.WriteLine("Something broke");
                break;
        }
    }
}
