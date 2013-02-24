using System;
using MobilePhone.Common;

namespace MobilePhone.Common
{
    public class GSMCallHistoryTest
    {
        public static void RunTest() {
            GSM myPhone = new GSM("Toyaga","Motorola");
            Random generator = new Random();
            for (int i = 0; i < generator.Next(5,15); i++)
            {
                string randomPhone = generator.Next(100000, 999999).ToString();
                int randomDuration = generator.Next(10, 900);
                string randomDate = generator.Next(1, 32) + "." + generator.Next(1, 13) + ".2013";
                string randomTime = generator.Next(0, 25) + ":" + generator.Next(0, 61);
                Call newCall = new Call(randomPhone, randomDuration, randomDate, "time");
                myPhone.AddCall(newCall);
            }

            myPhone.PrintHistory();
            Console.WriteLine(String.Format("Bill: {0}", myPhone.CalculateBill(0.37M)));
            //TODO remove longest call, calculate price again

            myPhone.ClearHistory();
            Console.WriteLine("Cleared history");
            myPhone.PrintHistory();
        }
    }


}
