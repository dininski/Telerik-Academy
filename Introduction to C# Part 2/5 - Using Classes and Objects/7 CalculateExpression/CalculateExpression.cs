using System;
using System.Collections.Generic;

class CalculateExpression
{
    public static int LEFT_ASSOC = 0;
    public static int RIGHT_ASSOC = 1;

    public static Dictionary<string, int[]> OPERATORS = new Dictionary<string, int[]>();

    public static void FillOperators()
    {
        OPERATORS.Add("+", new int[] { 0, LEFT_ASSOC });
        OPERATORS.Add("-", new int[] { 0, LEFT_ASSOC });
        OPERATORS.Add("*", new int[] { 5, LEFT_ASSOC });
        OPERATORS.Add("/", new int[] { 5, LEFT_ASSOC });
        OPERATORS.Add("%", new int[] { 5, LEFT_ASSOC });
        OPERATORS.Add("^", new int[] { 10, RIGHT_ASSOC });
    }

    public static bool IsOperator(string token)
    {
        return OPERATORS.ContainsKey(token);
    }

    public static bool IsAssociative(string token, int type)
    {
        if (OPERATORS[token][1] == type)
        {
            return true;
        }
        return false;
    }

    public static int CmpPrecedence(string token1, string token2)
    {
        return OPERATORS[token1][0] - OPERATORS[token2][0];
    }

    public static string[] ConvertToRPN(string[] tokens)
    {
        List<string> output = new List<string>();
        Stack<string> stack = new Stack<string>();

        foreach (var token in tokens)
        {
            if (IsOperator(token))
            {
                while (stack.Count != 0 && IsOperator(stack.Peek()))
                {
                    if ((IsAssociative(token, LEFT_ASSOC) && CmpPrecedence(token, stack.Peek()) <= 0) || (IsAssociative(token, RIGHT_ASSOC) && CmpPrecedence(token, stack.Peek()) < 0))
                    {
                        output.Add(stack.Pop());
                        continue;
                    }
                    break;
                }
                stack.Push(token);
            }
            else if (token.Equals("("))
            {
                stack.Push(token);
            }
            else if (token.Equals(")"))
            {
                while (stack.Count != 0 && !stack.Peek().Equals("("))
                {
                    output.Add(stack.Pop());
                }
            }
            else
            {
                output.Add(token);
            }
        }
        while (stack.Count != 0)
        {
            output.Add(stack.Pop());
        }

        string[] result = output.ToArray();
        return result;
    }

    static void Main(string[] args)
    {
        FillOperators();
        string expression = "( 1.9 + 2 ) * ( 3.6 / 4.1 ) ^ ( 5 + 6 )";
        String[] input = expression.Split(' ');
        String[] output = ConvertToRPN(input);
        Console.WriteLine("The expression in Reverse Polish Notation: ");
        foreach (var item in output)
        {
            Console.Write("{0} ", item);
        }
    }
}
