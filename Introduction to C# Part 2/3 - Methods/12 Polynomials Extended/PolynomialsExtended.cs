using System;

class PolynomialsExtended
{
    public static void FillPolinomial(ref int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            Console.Write("Please enter the coefficient of x to the power of {0}:", i);
            polynomial[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
    }

    public static int[] Addition(int[] firstPoly, int[] secondPoly, bool addition = true)
    {
        //check if the firstPolynomial is longer, i.e. a bigger number than the second poly
        //or if both are equal run Addition() for with the polynomial with bigger coefficient at the higher power of x
        if (firstPoly.Length < secondPoly.Length || (firstPoly.Length == secondPoly.Length && firstPoly[firstPoly.Length - 1] < secondPoly[secondPoly.Length - 1]))
        {
            return Addition(secondPoly, firstPoly, addition);
        }

        int[] sumOfPoly = new int[firstPoly.Length];

        for (int i = 0; i < secondPoly.Length; i++)
        {
            //if it is addition - add the polynomials
            if (addition)
            {
                sumOfPoly[i] = firstPoly[i] + secondPoly[i];
            }
            //otherwise substract them
            else
            {
                sumOfPoly[i] = firstPoly[i] - secondPoly[i];
            }
        }

        for (int i = secondPoly.Length; i < firstPoly.Length; i++)
        {
            sumOfPoly[i] = firstPoly[i];
        }

        return sumOfPoly;
    }

    static int[] MultiplyPoly(int[] poly1, int[] poly2)
    {
        if (poly1.Length > poly2.Length)
        {
            return MultiplyPoly(poly2, poly1);
        }
        int[] result = new int[poly2.Length];
        for (int i = 0; i < poly1.Length; i++)
        {
            result[i] = poly1[i] * poly2[i];
        }
        for (int j = poly1.Length; j < poly2.Length; j++)
        {
            result[j] = poly2[j];
        }
        return result;
    }

    static void PrintPolynomial(int[] finalResult)
    {
        string sign = "";
        for (int i = finalResult.Length - 1; i >= 0; i--)
        {
            if (finalResult[i] >= 0 && i != finalResult.Length - 1)
            {
                sign = "+";
            }
            else
            {
                sign = "";
            }
            Console.Write("{2}{0}*x^{1}", finalResult[i], i, sign);
        }
        Console.WriteLine();
    }



    static void Main(string[] args)
    {
        Console.Write("Please enter the power of the first polynomial: ");
        int poly1Length = int.Parse(Console.ReadLine()) + 1;
        int[] firstPolynomial = new int[poly1Length];
        FillPolinomial(ref firstPolynomial);

        Console.Write("Please enter the power of the second polynomial: ");
        int poly2Length = int.Parse(Console.ReadLine()) + 1;
        int[] secondPolynomial = new int[poly2Length];
        FillPolinomial(ref secondPolynomial);

        int[] sum = Addition(firstPolynomial, secondPolynomial);
        int[] difference = Addition(firstPolynomial, secondPolynomial, false);
        int[] product = MultiplyPoly(firstPolynomial, secondPolynomial);
        Console.WriteLine("The sum of the polynomials is: ");
        PrintPolynomial(sum);

        Console.WriteLine("The difference between the polynomials is:");
        PrintPolynomial(difference);

        Console.WriteLine("The product of the polynomials is:");
        PrintPolynomial(product);
    }
}
