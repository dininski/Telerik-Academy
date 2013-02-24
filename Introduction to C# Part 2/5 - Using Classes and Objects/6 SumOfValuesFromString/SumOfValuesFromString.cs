using System;

class SumOfValuesFromString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter all the values that you want to calculate the sum to, separated by spaces: ");
        string userInputValues = Console.ReadLine();
        string[] separatedValues = userInputValues.Split(' ');
        int sum = 0;
        for (int i = 0; i < separatedValues.Length; i++)
        {
            sum += int.Parse(separatedValues[i]);
        }
        Console.WriteLine("The sum of {0} is {1}", userInputValues, sum);
    }
}