using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone.Common;

namespace MobilePhone.Tests
{
    [TestClass]
    public class GSMCallHistoryTest
    {
        static GSM myPhone = new GSM("Phone", "Me");

        private TestContext info;
        public TestContext TestContext {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        [TestMethod]
        public void CallHistoryFill()
        {
            Call mom = new Call("+359555123456", 75, "22.3.2013", "00:12:34");
            Call dad = new Call("+359888111222", 35, "21.2.2013", "11:22:33");
            Call girlfriend = new Call("+666666666", 110, "22.3.2013", "11:11:11");
            Call cat = new Call("+35912345666", 1240, "21.3.2013", "01:23:12");
            myPhone.CallHistory.Add(mom);
            myPhone.CallHistory.Add(dad);
            myPhone.CallHistory.Add(girlfriend);
            myPhone.CallHistory.Add(cat);
        }

        [TestMethod]
        public void CallHistoryDisplay()
        {
            foreach (Call call in myPhone.CallHistory)
            {
                TestContext.WriteLine(call.ToString());
            }
        }

        [TestMethod]
        public void CallHistoryBaseCase()
        {
            decimal bill = myPhone.CalculateBill(0.37M);
            Assert.IsTrue(bill == 9.62M);
        }

        [TestMethod]
        public void CallHistoryWithLongestCallRemoved()
        {
            myPhone.RemoveLongestCall();
            decimal bill = myPhone.CalculateBill(0.37M);
            Assert.IsTrue(bill == 1.85M);
        }

        [TestMethod]
        public void CallHistoryBlankHistory()
        {
            myPhone.ClearHistory();
            foreach (Call call in myPhone.CallHistory)
            {
                Assert.IsNull(call);
            }
        }

    }
}
