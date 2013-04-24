namespace Print_Statistics_Refactor
{
    using System;

    public class Printer
    {
        public static void Main()
        {
            Printer printer = new Printer();
            // some test valules to check if everything is working correctly
            double[] someValues = new double[] { 1.4, 1.3, 3.8 };
            printer.PrintStatistics(someValues, 3);
        }

        public void PrintStatistics(double[] statistics, int numberOfEntries)
        {
            this.PrintMax(statistics, numberOfEntries);
            this.PrintMin(statistics, numberOfEntries);
            this.PrintAvg(statistics, numberOfEntries);
        }

        public void PrintMax(double[] statistics, int numberOfEntriesToPrint)
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

            Console.WriteLine(maxNumberInStatistics);
        }

        public void PrintMin(double[] statistics, int numberOfEntriesToPrint)
        {
            double minNumberInStatistics;
            minNumberInStatistics = statistics[0];
            for (int i = 0; i < numberOfEntriesToPrint; i++)
            {
                if (statistics[i] < minNumberInStatistics)
                {
                    minNumberInStatistics = statistics[i];
                }
            }

            Console.WriteLine(minNumberInStatistics);
        }

        public void PrintAvg(double[] statistics, int numberOfEntriesToPrint)
        {
            double sum;
            sum = 0;
            for (int i = 0; i < numberOfEntriesToPrint; i++)
            {
                sum += statistics[i];
            }

            double average = sum / numberOfEntriesToPrint;
            Console.WriteLine(average);
        }
    }
}
