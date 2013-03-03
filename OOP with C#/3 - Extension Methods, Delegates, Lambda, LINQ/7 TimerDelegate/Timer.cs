using System;
using System.Diagnostics;

//Using delegates write a class Timer that can execute certain method at each t seconds.

public class Timer
{
    public delegate void delegatedMethods();

    public delegatedMethods d;

    public void startTimer(int t)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        while (true)
        {
            if (sw.ElapsedMilliseconds >= t*1000)
            {
                Console.WriteLine("Boom");
                sw.Restart();
            }
        }
    }

    static void testPrint()
    {
        Console.WriteLine("Something");
    }

    public static void Main()
    {
        Timer t = new Timer();
        t.d = new delegatedMethods(Timer.testPrint);
        t.startTimer(1);
        Console.WriteLine("asd");
    }
}
