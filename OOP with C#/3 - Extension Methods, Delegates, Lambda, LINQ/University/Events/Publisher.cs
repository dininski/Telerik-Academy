using System;
using System.Collections.Generic;

namespace ProjectLibrary.Events
{
    public class Publisher
    {
        public event EventHandler<TimerEventArgs> MyEvent;

        public void StartTimer()
        {
            OnTimerEvent(new TimerEventArgs("test", 4));
        }

        protected virtual void OnTimerEvent(TimerEventArgs e)
        {
            EventHandler<TimerEventArgs> tempHandler = MyEvent;

            if (tempHandler != null)
            {
                tempHandler(this, e);
            }
        }
    }
}
