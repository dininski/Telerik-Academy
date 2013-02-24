using System;

class Polynomials
{
    public static void FillPolinomial(ref int[] polynomial)
    {
        for (int i = polynomial.Length-1; i >= 0; i--)
        {
            Console.Write("Please enter the coefficient of x to the power of {0}:", i);
            polynomial[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
    }

    public static int[] Addition(int[] firstPoly, int[] secondPoly)
    {
        if (firstPoly.Length < secondPoly.Length)
        {
            return Addition(secondPoly, firstPoly);
        }

        int[] sumOfPoly = new int[firstPoly.Length];

        for (int i = 0; i < secondPoly.Length; i++)
        {
            sumOfPoly[i] = firstPoly[i] + secondPoly[i];
        }

        for (int i = secondPoly.Length; i < firstPoly.Length; i++)
        {
            sumOfPoly[i] = firstPoly[i];
        }

        return sumOfPoly;
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

        Console.WriteLine("The sum of the polynomial is: ");
        for (int i = sum.Length-1; i >= 0; i--)
        {
            Console.WriteLine("{0}*x^{1}", sum[i], i);
        }
    }
}
