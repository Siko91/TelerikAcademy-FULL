using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    class MobilePhoneTest
    {
        private List<MobilePhone> MobilPhoneList = new List<MobilePhone>();

        public void AddToList(MobilePhone phone)
        {
            MobilPhoneList.Add(phone);
        }
        public List<string> GetPhonesInfo()
        {
            List<string> PhonesInfo = new List<string>();

            foreach (MobilePhone phone in MobilPhoneList)
            {
                PhonesInfo.Add(phone.ToString());
            }

            return PhonesInfo;
        }
        public string IPhone4S
        {
            get { return MobilePhone.IPhone4S; }
        }
    }
}
