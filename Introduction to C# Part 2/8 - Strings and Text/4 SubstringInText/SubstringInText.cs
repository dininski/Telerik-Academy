using System;

class SubstringInText
{
    static void Main(string[] args)
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string textLowerCase = text.ToLower();
        string lookingFor = "in";
        int position = -1;
        int counter = 0;
        while ((position = textLowerCase.IndexOf(lookingFor, position + 1)) >= 0)
        {
            counter++;
        }
        Console.WriteLine(counter);
    }
}
