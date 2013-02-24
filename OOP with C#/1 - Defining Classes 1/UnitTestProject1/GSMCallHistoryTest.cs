using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone.Common;

namespace MobilePhone.Tests
{
    [TestClass]
    public class GSMCallHistoryTest
    {
        [TestMethod]
        public void BaseCase()
        {
            GSM myPhone = new GSM("Phone", "Me");
            Call mom = new Call("+359555123456",75,"22.3.2013","00:12:34");
            Call dad = new Call("+359888111222", 35, "21.2.2013", "11:22:33");
            Call girlfriend = new Call("+666666666", 110, "22.3.2013", "11:11:11");
            Call cat = new Call("+35912345666", 1240, "21.3.2013", "01:23:12");
            myPhone.CallHistory.Add(mom);
            myPhone.CallHistory.Add(dad);
            myPhone.CallHistory.Add(girlfriend);
            myPhone.CallHistory.Add(cat);
            Console.WriteLine(myPhone.CallHistory);
            decimal bill = myPhone.CalculateBill(0.37M);
            Assert.IsTrue(bill == 9.62M);
        }

        [TestMethod]
        public void WithLongestCallRemoved()
        {
            GSM myPhone = new GSM("Phone", "Me");
            Call mom = new Call("+359555123456", 75, "22.3.2013", "00:12:34");
            Call dad = new Call("+359888111222", 35, "21.2.2013", "11:22:33");
            Call girlfriend = new Call("+666666666", 110, "22.3.2013", "11:11:11");
            Call cat = new Call("+35912345666", 1240, "21.3.2013", "01:23:12");
            myPhone.CallHistory.Add(mom);
            myPhone.CallHistory.Add(dad);
            myPhone.CallHistory.Add(girlfriend);
            myPhone.CallHistory.Add(cat);
            Console.WriteLine(myPhone.CallHistory);
            myPhone.RemoveLongestCall();
            decimal bill = myPhone.CalculateBill(0.37M);
            Assert.IsTrue(bill == 1.85M);
        }

        [TestMethod]
        public void WithLongestCallRemovedAndClearedHistory()
        {
            GSM myPhone = new GSM("Phone", "Me");
            Call mom = new Call("+359555123456", 75, "22.3.2013", "00:12:34");
            Call dad = new Call("+359888111222", 35, "21.2.2013", "11:22:33");
            Call girlfriend = new Call("+666666666", 110, "22.3.2013", "11:11:11");
            Call cat = new Call("+35912345666", 1240, "21.3.2013", "01:23:12");
            myPhone.CallHistory.Add(mom);
            myPhone.CallHistory.Add(dad);
            myPhone.CallHistory.Add(girlfriend);
            myPhone.CallHistory.Add(cat);
            Console.WriteLine(myPhone.CallHistory);
            myPhone.RemoveLongestCall();
            decimal bill = myPhone.CalculateBill(0.37M);
            Assert.IsTrue(bill == 1.85M);
            myPhone.ClearHistory();
            Console.WriteLine(myPhone.CallHistory);
        }
    }
}
