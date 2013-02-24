using System;

namespace MobilePhone.Common
{
    public class Battery
    {
        public BatteryType Type { get; set; }
        public string Model { get; set; }
        public double? hoursIdle;
        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.hoursIdle = value;
            }
        }

        public double? hoursTalk;
        public double? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException();
                }
                this.hoursTalk = value;
            }
        }

        public Battery(string model)
            : this(model, null)
        {
        }

        //a copy constructor - creates a new object, instead of using the reference to the old one
        public Battery(Battery oldBattery)
            : this(oldBattery.Model, oldBattery.HoursIdle, oldBattery.HoursTalk)
        {
        }

        public Battery(string model, double? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }

        public Battery(string model, double? hoursIdle, double? hoursTalk)
            : this(model, hoursIdle, hoursTalk, BatteryType.LiIon)
        {
        }

        public Battery(string model, double? hoursIdle, double? hoursTalk, BatteryType batType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = batType;
        }

        override public string ToString()
        {
            return String.Format("Battery Model: {0}\nHours Idle: {1}\nHours Talk: {2}", Model, HoursIdle, HoursTalk);
        }
    }
}
