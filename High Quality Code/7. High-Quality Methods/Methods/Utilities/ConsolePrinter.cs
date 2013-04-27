namespace Methods.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ConsolePrinter
    {
        /// <summary>
        /// Prints <paramref name="number"/> to the console as percent
        /// </summary>
        /// <param name="number">Number to print</param>
        public static void PrintNumberAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        /// <summary>
        /// Prints <paramref name="number"/> with offset of <paramref name="offset"/>
        /// </summary>
        /// <param name="number">A number to print</param>
        /// <param name="offset">Console offset</param>
        public static void PrinNumbertWithOffset(object number, int offset)
        {
            string formatString = "{0," + offset + "}";
            Console.WriteLine(formatString, number);
        }

        /// <summary>
        /// Prints <paramref name="number"/> to the console with floating
        /// precision of 2
        /// </summary>
        /// <param name="number">Number to print</param>
        public static void PrintFloatWithPrecision(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }
    }
}
