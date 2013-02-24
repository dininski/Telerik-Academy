using System;
using MobilePhone.Common;
using System.Text;

namespace MobilePhone.Common
{
    public class GSMTest
    {
        GSM[] phones = new GSM[3];

        public GSMTest()
        {
            for (int i = 0; i < phones.Length; i++)
            {
                Battery someBattery = new Battery("Samsung",24+i,24+i,BatteryType.NiCd);
                Display someDisplay = new Display(16000);
                phones[i] = new GSM("Toyaga", "Dyrvodeleca",1000+(200*i),someDisplay,someBattery);
            }
        }

        override public string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (GSM phone in phones)
            {
                result.AppendLine(phone.ToString());
                result.AppendLine();
            }
            result.AppendLine(GSM.IPhone4s.ToString());

            return result.ToString();
        }
    }
}
