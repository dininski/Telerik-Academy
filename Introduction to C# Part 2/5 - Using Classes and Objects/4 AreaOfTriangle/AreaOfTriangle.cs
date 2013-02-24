using System;

class AreaOfTriangle
{
    public static double AreaBySideAndAlt(double side, double altitude)
    {
        return (side * altitude) / 2.0;
    }

    public static double AreaByThreeSides(double firstSide, double secondSide, double thirdSide)
    {
        double semiperimeter = (firstSide + secondSide + thirdSide) / 2;
        return Math.Sqrt(semiperimeter * (semiperimeter - firstSide) * (semiperimeter - secondSide) * (semiperimeter - thirdSide));
    }

    public static double AreaByTwoSidesAndAngle(double firstSide, double secondSide, double angle)
    {
        return (firstSide * secondSide * Math.Sin(angle)) / 2;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Triangle with side 4 and height 5: {0}", AreaBySideAndAlt(4, 5));
        Console.WriteLine("Triangle with sides 11.8, 17.2 and 18.9 has area: {0}", AreaByThreeSides(11.8, 17.2, 18.9));
        Console.WriteLine("Triangle with sides 21.2, 23.7 and angle between them 30 deg has area: {0}", AreaByTwoSidesAndAngle(21.2, 23.7, 0.523598776));
    }
}