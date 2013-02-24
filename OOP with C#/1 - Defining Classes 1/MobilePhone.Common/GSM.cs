using System;
using MobilePhone.Common;
using System.Collections.Generic;

public class GSM
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    private static GSM iPhone4S;
    public static GSM IPhone4s { get { return iPhone4S; } }
    private List<Call> callHistory;
    public List<Call> CallHistory { get { return this.callHistory; } }

    private decimal? price;
    public decimal? Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.price = value;
        }
    }


    //both for Battery and Display I am creating a new instance, 
    //as both of them are reference type

    private Battery batteryInfo;
    public Battery BatteryInfo
    {
        get { return this.batteryInfo; }
        set { this.batteryInfo = new Battery(value); }
    }

    private Display displayInfo;
    public Display DisplayInfo
    {
        get { return this.displayInfo; }
        set { this.displayInfo = new Display(value); }
    }

    //initialize the static iPhone GSM
    static GSM()
    {
        DisplaySize iPhoneDisplaySize = new DisplaySize(1136, 640);
        Display iPhoneDisplay = new Display(32000, iPhoneDisplaySize);
        Battery iPhoneBattery = new Battery("Samsung", 24, 24, BatteryType.LiIon);
        iPhone4S = new GSM("4S", "Apple", 1000000, iPhoneDisplay, iPhoneBattery);
    }

    public GSM(string model, string manufacturer)
        : this(model, manufacturer, null)
    {
        this.callHistory = new List<Call>();
    }

    public GSM(string model, string manufacturer, decimal? price)
        : this(model, manufacturer, price, new Display())
    {
    }

    public GSM(string model, string manufacturer, decimal? price, Display displayInfo)
        : this(model, manufacturer, price, displayInfo, new Battery(""))
    {
    }

    public GSM(string model, string manufacturer, decimal? price, Display displayInfo, Battery batteryInfo)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.DisplayInfo = displayInfo;
        this.BatteryInfo = new Battery(batteryInfo);
    }

    override public string ToString()
    {
        return String.Format("Model: {0}\nManufacturer: {1}\nPrice: {2}\nDisplay Information\n{3}\nBattery Information\n{4}"
           , Model, Manufacturer, Price, DisplayInfo, BatteryInfo);
    }

    public void AddCall(Call newCall)
    {
        CallHistory.Add(newCall);
    }

    public void DeleteCall(int callIndex)
    {
        CallHistory.RemoveAt(callIndex);
    }

    public void ClearHistory()
    {
        CallHistory.Clear();
    }

    public void PrintHistory()
    {
        foreach (Call call in CallHistory)
        {
            Console.WriteLine(call);
        }
    }

    public decimal CalculateBill(decimal rate)
    {
        decimal result = 0;
        foreach (Call call in CallHistory)
        {
            result += (decimal)(Math.Ceiling((decimal)call.Duration / 60))*rate;
        }
        return result;
    }
}