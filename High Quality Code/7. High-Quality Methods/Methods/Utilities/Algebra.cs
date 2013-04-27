namespace Methods.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Algebra
    {
        /// <summary>
        /// Finds the highest element from <paramref name="elements"/>.
        /// </summary>
        /// <param name="elements">Integer elements, from which to search for the highest</param>
        /// <returns>Returns the highest element as an integer</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument must not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("At least one argument must be provided!");
            }

            int maxNumber = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }
    }
}
