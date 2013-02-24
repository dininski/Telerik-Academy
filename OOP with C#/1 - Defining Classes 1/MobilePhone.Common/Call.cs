using System;

namespace MobilePhone.Common
{
    public class Call
    {
        public string DialedPhone { get; set; }
        public int Duration { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }


        public Call(string dialedPhone, int callDuration, string date, string time)
        {
            this.DialedPhone = dialedPhone;
            this.Duration = callDuration;
            this.Date = date;
            this.Time = time;
        }

        public override string ToString()
        {
            return String.Format("Call duration: {0}s\nDialed phone number: {1}\nTime: {2}\nDate: {3}\n", Duration, DialedPhone, Time, Date);
        }
    }
}
