using System;
using System.Collections.Generic;
using ProjectLibrary.Events;

//* Read in MSDN about the keyword event in C# and how to publish events. 
//Re-implement the above using .NET events and following the best practices.

class TimerEvent
{
    static void Main(string[] args)
    {
        Timer t = new Timer();
        Listener listen = new Listener();
        listen.Subscribe(t);
        t.StartTimer();
    }
}
