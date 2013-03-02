using System;
using System.Collections.Generic;
using ProjectLibrary.Events;

//* Read in MSDN about the keyword event in C# and how to publish events. 
//Re-implement the above using .NET events and following the best practices.

class TimerEvent
{
    static void Main(string[] args)
    {
        Publisher pub = new Publisher();
        Subscriber sub1 = new Subscriber(pub);
        
        pub.StartTimer();
    }
}
