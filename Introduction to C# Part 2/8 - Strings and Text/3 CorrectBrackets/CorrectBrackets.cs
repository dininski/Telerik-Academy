using System;

class CorrectBrackets
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter an expression with brackets:");
        var expression = Console.ReadLine();
        int brackets = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (brackets < 0)
            {
                break;
            }
            if (expression[i] == '(')
            {
                brackets++;
            }
            else if (expression[i] == ')')
            {
                brackets--;
            }

        }
        if (brackets == 0)
        {
            Console.WriteLine("The brackets are put correctly.");
        }
        else
        {
            Console.WriteLine("The brackets are put incorrectly");
        }
    }
}