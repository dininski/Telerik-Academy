using System;
using System.Collections.Generic;

namespace ProjectLibrary.Events
{
    public class Timer
    {
        public event TimerHandler Tick;
        public EventArgs e = null;
        public delegate void TimerHandler(Timer t, EventArgs e);

        public void StartTimer()
        {
            int counter = 0;
            while (counter < 10)
            {
                System.Threading.Thread.Sleep(1000);
                if (Tick != null)
                {
                    Tick(this, e);
                }
                counter++;
            }
        }
    }
}
