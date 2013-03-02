using System;
using System.Collections.Generic;

namespace ProjectLibrary.Events
{
    public class TimerEventArgs
    {
        public int Seconds { get; set; }
        public string Message { get; set; }
        public TimerEventArgs(string m, int t)
        {
            Seconds = t;
            Message = m;
        }
    }
}
