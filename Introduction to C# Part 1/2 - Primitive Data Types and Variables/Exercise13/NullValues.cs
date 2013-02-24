using System;

namespace Exercise13
{
    class NullValues
    {
        static void Main()
        {
            int? integerVar=null;
            double? doubleVar=null;
            Console.WriteLine(integerVar);
            Console.WriteLine(doubleVar);
            integerVar += 4;
            doubleVar += 4.2;
            Console.WriteLine(integerVar);
            Console.WriteLine(doubleVar);
            integerVar = 3;
            doubleVar = 1.321;
            Console.WriteLine(integerVar);
            Console.WriteLine(doubleVar);
        }
    }
}
