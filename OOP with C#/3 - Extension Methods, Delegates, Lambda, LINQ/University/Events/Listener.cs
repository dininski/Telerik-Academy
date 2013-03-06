using System;
using System.Collections.Generic;

namespace ProjectLibrary.Events
{
    public class Listener
    {
        public void Subscribe(Timer t)
        {
            t.Tick += new Timer.TimerHandler(EventCaught);
        }

        public void EventCaught(Timer t, EventArgs e)
        {
            Console.WriteLine("Tick!");
        }
    }
}
