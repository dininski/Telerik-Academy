using System;
class WhatsYourName
{
    static void helloUser(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        helloUser(name);
    }
}