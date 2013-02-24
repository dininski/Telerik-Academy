using System;


class Program
{
    static void Main()
    {
        while (true)
        {

            String result = "";
            Console.WriteLine("Please enter a number between 0 and 999:");
            int userInput = int.Parse(Console.ReadLine());
            int hundreds = userInput / 100;
            int tens = (userInput - hundreds * 100) / 10;
            int singles = userInput - hundreds * 100 - tens * 10;

            if (!(userInput / 1000 >= 1))
            {
                if (userInput == 0)
                {
                    result = "Zero";
                }
                else if (hundreds > 0)
                {
                    switch (hundreds)
                    {
                        case 1:
                            result += "One ";
                            break;
                        case 2:
                            result += "Two ";
                            break;
                        case 3:
                            result += "Three ";
                            break;
                        case 4:
                            result += "Four ";
                            break;
                        case 5:
                            result += "Five ";
                            break;
                        case 6:
                            result += "Six ";
                            break;
                        case 7:
                            result += "Seven ";
                            break;
                        case 8:
                            result += "Eight ";
                            break;
                        case 9:
                            result += "Nine ";
                            break;
                        default:
                            Console.WriteLine("Something broke with the hundreds");
                            break;
                    }
                    result += "hundred ";
                }
                if (tens > 0)
                {
                    if (tens == 1) // if it is zero add AND and stuff
                    {
                        if (hundreds>0){
                            result += "and ";
                        }
                        switch (singles)
                        {
                            case 0:
                                result += "ten";
                                break;
                            case 1:
                                result += "eleven";
                                break;
                            case 2:
                                result += "twelve";
                                break;
                            case 3:
                                result += "thirteen";
                                break;
                            case 4:
                                result += "fourteen";
                                break;
                            case 5:
                                result += "fifteen";
                                break;
                            case 6:
                                result += "sixteen";
                                break;
                            case 7:
                                result += "seventeen";
                                break;
                            case 8:
                                result += "eighteen";
                                break;
                            case 9:
                                result += "nineteen";
                                break;
                            default:
                                Console.WriteLine("Something broke with 11-19");
                                break;
                        }
                    }
                    else
                    {
                        if (singles == 0)
                        {
                            result += "and ";
                        }
                        switch (tens)
                        {
                            case 2:
                                result += "twenty ";
                                break;
                            case 3:
                                result += "thirty ";
                                break;
                            case 4:
                                result += "fourty ";
                                break;
                            case 5:
                                result += "fifty ";
                                break;
                            case 6:
                                result += "sixty ";
                                break;
                            case 7:
                                result += "seventy ";
                                break;
                            case 8:
                                result += "eighty ";
                                break;
                            case 9:
                                result += "ninety ";
                                break;
                            default:
                                break;
                        }
                        if (singles > 0)
                        {
                            switch (singles)
                            {
                                case 1:
                                    result += "one ";
                                    break;
                                case 2:
                                    result += "two ";
                                    break;
                                case 3:
                                    result += "three ";
                                    break;
                                case 4:
                                    result += "four ";
                                    break;
                                case 5:
                                    result += "five ";
                                    break;
                                case 6:
                                    result += "six ";
                                    break;
                                case 7:
                                    result += "seven ";
                                    break;
                                case 8:
                                    result += "eight ";
                                    break;
                                case 9:
                                    result += "nine ";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } if (singles > 0 && tens == 0)
                {
                    if (hundreds > 0)
                    {
                        result += "and ";
                    }
                    switch (singles)
                    {
                        case 1:
                            result += "one ";
                            break;
                        case 2:
                            result += "two ";
                            break;
                        case 3:
                            result += "three ";
                            break;
                        case 4:
                            result += "four ";
                            break;
                        case 5:
                            result += "five ";
                            break;
                        case 6:
                            result += "six ";
                            break;
                        case 7:
                            result += "seven ";
                            break;
                        case 8:
                            result += "eight ";
                            break;
                        case 9:
                            result += "nine ";
                            break;
                        default:
                            break;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("The number is bigger than 999.");
            }
            Console.WriteLine(result);
            //Console.WriteLine(userInput);
            //Console.WriteLine(hundreds);
            //Console.WriteLine(tens);
            //Console.WriteLine(singles);
        }
    }
}

