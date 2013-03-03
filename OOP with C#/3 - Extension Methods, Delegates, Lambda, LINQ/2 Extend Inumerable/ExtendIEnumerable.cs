using System;
using System.Collections.Generic;

//Implement a set of extension methods for IEnumerable<T> that implement the 
//following group functions: sum, product, min, max, average.


static class ExtendIEnumerable
{

    public static T Sum<T>(this IEnumerable<T> col)
    {
        dynamic sum = 0;
        foreach (var item in col)
        {
            sum += item;
        }
        return sum;
    }


    public static T Product<T>(this IEnumerable<T> col)
    {
        dynamic product = 1;
        foreach (var item in col)
        {
            product *= item;
        }
        return product;
    }

    public static T Max<T>(this IEnumerable<T> col)
        where T:IComparable<T>
    {
        return GetMaxMin<T>(col, true);
    }

    public static T Min<T>(this IEnumerable<T> col)
        where T:IComparable<T>
    {
        return GetMaxMin<T>(col, false);
    }

    private static T GetMaxMin<T>(IEnumerable<T> col, bool wantMax) where T : IComparable<T>
    {
        IEnumerator<T> iterator = col.GetEnumerator();
        iterator.MoveNext();
        dynamic result = iterator.Current;
        while (iterator.MoveNext())
        {
            if (wantMax)
            {
                if (iterator.Current.CompareTo(result) > 0)
                {
                    result = iterator.Current;
                }
            }
            else
            {
                if (iterator.Current.CompareTo(result) < 0)
                {
                    result = iterator.Current;
                }
            }
        }
        return result;
    }

    public static double Average<T>(this IEnumerable<T> col)
    {
        int count = 0;
        foreach (var item in col)
        {
            count++;
        }
        return Convert.ToDouble(col.Sum<T>())/count;
    }


    static void Main(string[] args)
    {
        IEnumerable<double> test = new double[] { 38.1, 5.6, 43, 8, 9, 3, 1 };
        Console.WriteLine(test.Max<double>());
        Console.WriteLine(test.Min<double>());
        Console.WriteLine(test.Sum<double>());
        Console.WriteLine(test.Product<double>());
        Console.WriteLine(test.Average<double>());


    }
}