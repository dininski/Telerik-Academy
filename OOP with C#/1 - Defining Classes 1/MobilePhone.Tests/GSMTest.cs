using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone.Common;

namespace MobilePhone.Tests
{
    [TestClass]
    public class GSMTest
   { 
        [TestMethod]
        public void OnlyRequiredInfo()
        {
            GSM somePhone = new GSM("Shiba", "To");
            Console.WriteLine(somePhone);
        }

        [TestMethod]
        public void GSMWithMoreDetails()
        {
            GSM somePhoneWithMoreDetails = new GSM("Gega", "Mega", 1000M, new Display());
            Console.WriteLine(somePhoneWithMoreDetails);
        }

        [TestMethod]
        public void GSMWithAllDetails()
        {
            Display someDisplay = new Display(45000,new DisplaySize(1024,768));
            Battery superBattery = new Battery("kon",1000,1000,BatteryType.NiMH);
            GSM megaPhone = new GSM("Super Phone", "Krypton", 750,someDisplay,superBattery);
            Console.WriteLine(megaPhone);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GSMWithNegativePrice()
        {
            GSM iFake = new GSM("Fake", "Fone", -100);
        }

        [TestMethod]
        public void PrintIPhoneInformation()
        {
            Console.WriteLine(GSM.IPhone4s);
        }
    }
}
