namespace Print_Statistics_Refactor
{
    using System;

    public class Printer
    {
        public static void Main()
        {
            Printer printer = new Printer();
            double[] someValues = new double[] { 1.4, 1.3, 3.8 };
            printer.PrintStatistics(someValues, 3);
        }

        public void PrintStatistics(double[] statistics, int numberOfEntriesToPrint)
        {
            double maxNumberInStatistics;
            maxNumberInStatistics = statistics[0];
            for (int i = 0; i < numberOfEntriesToPrint; i++)
            {
                if (statistics[i] > maxNumberInStatistics)
                {
                    maxNumberInStatistics = statistics[i];
                }
            }

            this.PrintMax(maxNumberInStatistics);
            double minNumberInStatistics;
            minNumberInStatistics = statistics[0];
            for (int i = 0; i < numberOfEntriesToPrint; i++)
            {
                if (statistics[i] < minNumberInStatistics)
                {
                    minNumberInStatistics = statistics[i];
                }
            }

            this.PrintMin(minNumberInStatistics);
            double sum;
            sum = 0;
            for (int i = 0; i < numberOfEntriesToPrint; i++)
            {
                sum += statistics[i];
            }

            this.PrintAvg(sum / numberOfEntriesToPrint);
        }

        // using three separate methods as the problem definition does not provide details
        // on the concrete implementation of those methods - they might be doing different things
        // and not only printing the value.
        public void PrintMax(double maximum)
        {
            Console.WriteLine(maximum);
        }

        public void PrintMin(double minimum)
        {
            Console.WriteLine(minimum);
        }

        public void PrintAvg(double average)
        {
            Console.WriteLine(average);
        }
    }
}
