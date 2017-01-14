using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    class CallHistoryTest
    {
        public static double DefaultPrice = 0.37;

        private MobilePhone phone;

        public CallHistoryTest(MobilePhone phone)
        {
            this.phone = phone;
        }
        public void AddCall(Call call)
        {
            this.phone.AddCall(call);
        }
        public double CalcPrice()
        {
            return this.phone.CalculatePriceOfCalls(CallHistoryTest.DefaultPrice);
        }
        public void ClearCallHistory()
        {
            this.phone.ClearCallHistory();
        }
        public void RemoveLongestCall()
        {
            if (this.phone.CallHistory.Count() == 0)
            {
                throw new ArgumentException("Can not remove from an empty history");
            }

            uint max = 0;
            int index = 0; 

            for (int i = 0; i < this.phone.CallHistory.Count(); i++)
            {
                if (this.phone.CallHistory[i].Duration > max)
                {
                    max = this.phone.CallHistory[i].Duration;
                    index = i;
                }
            }
            this.phone.CallHistory.RemoveAt(index);
        }

        public string getHistoryToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Call call in this.phone.CallHistory)
            {
                result.Append("Call to " + call.DialedPhoneNumber + " ,at " + call.DateAndTime + " ,lasted " + call.Duration + " seconds \n");
            }

            return result.ToString();
        }
    }
}
