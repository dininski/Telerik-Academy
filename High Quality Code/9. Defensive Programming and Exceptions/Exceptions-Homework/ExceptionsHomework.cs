namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex < 0)
            {
                throw new ArgumentException("The starting index cannot be negative!");    
            }

            if (count == 0)
            {
                throw new ArgumentException("The subsequence length must be larger than 0!");
            }

            if (startIndex + count > arr.Length)
            {
                throw new ArgumentException("The length of the subsequence cannot be bigger that the length of the array");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("The ending length cannot be negative!");
            }

            if (count > str.Length)
            {
                throw new ArgumentException("The ending length cannot be longer that the string we are extracting from!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool IsPrime(int number)
        {
            // mark the number as prime, until we find a number that can divide it
            bool numberIsPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    numberIsPrime = false;
                }
            }

            return numberIsPrime;
        }

        public static void Main()
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            // The next two lines throw an expected exception, because of
            // invalid input. Uncomment them to double check.
            // var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            // Console.WriteLine(string.Join(" ", emptyarr));
            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));

            // The next line now throws an expected exception, because of 
            // invalid input. Uncomment it to double check.
            // Console.WriteLine(ExtractEnding("Hi", 100));
            if (IsPrime(23))
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime");
            }

            if (IsPrime(33))
            {
                Console.WriteLine("33 is prime.");
            }
            else
            {
                Console.WriteLine("33 is not prime");
            }

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}