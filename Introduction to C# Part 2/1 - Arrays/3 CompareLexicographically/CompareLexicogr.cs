using System;

class CompareLexicogr
{
    static void Main(string[] args)
    {
        char[] firstCharArray = { 'a', 'b', 'c', 'd', 'z', 'f'};
        char[] secondCharArray = { 'a', 'b', 'c', 'd', 'e', 'g' };


        if (firstCharArray.Length < secondCharArray.Length)
        {
            Console.WriteLine("The first character array is lexicographically first");
        }
        else if (secondCharArray.Length < firstCharArray.Length)
        {
            Console.WriteLine("The second character array is lexicographically first");
        }
        else
        {
            for (int i = 0; i < firstCharArray.Length; i++)
            {
                if (firstCharArray[i] < secondCharArray[i])
                {
                    Console.WriteLine("The first character array is lexicographically first");
                    break;
                }
                else if (secondCharArray[i] < firstCharArray[i])
                {
                    Console.WriteLine("The second character array is lexicographically first");
                    break;
                }
                else if (firstCharArray[i] == secondCharArray[i] && i == firstCharArray.Length - 1)
                {
                    Console.WriteLine("The character arrays are equal");
                }
            }

        }
    }
}