using System;
using System.Collections.Generic;

namespace ProjectLibrary.Events
{
    public class Subscriber
    {
        public Subscriber(Publisher pub, string message, int t)
        {
            pub.MyEvent += TimerEvent;
        }

        void TimerEvent(Object sender, TimerEventArgs t)
        {
            Console.WriteLine("Received message: {0}", t.Message);
        }
    }
}
