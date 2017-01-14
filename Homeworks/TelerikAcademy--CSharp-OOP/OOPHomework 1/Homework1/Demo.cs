using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    class Demo
    {
        static void Main(string[] args)
        {
            MobilePhone phone1 = new MobilePhone(
                "SomeModel",
                "SomeManufacturer", 
                50, 
                "MySelf", 
                new Display(5, 4, 24000000), 
                new Battery("Type4", 10, 6));

            MobilePhone phone2 = new MobilePhone(
                "SomeOtherModel",
                "SomeOtherManufacturer",
                new Display(8, 5, 48000000),
                BatteryType.Type1);
            phone2.Owner = "SomeOwner"; // program will throw exeption if owner is empty when the field is used for something.

            MobilePhoneTest test = new MobilePhoneTest();
            test.AddToList(phone1);
            test.AddToList(phone2);

            List<string> PhoneInfo = test.GetPhonesInfo();

            for (int i = 0; i < PhoneInfo.Count(); i++)
            {
                Console.WriteLine("Phone " + (i+1) + "\n-------------");
                Console.WriteLine(PhoneInfo[i]);
                Console.WriteLine();
            }

            CallHistoryTest testCalls = new CallHistoryTest(phone1);

            testCalls.AddCall(new Call("911"));
            testCalls.AddCall(new Call(DateTime.Today, "00004", 500));
            testCalls.AddCall(new Call(DateTime.Today.AddHours(4), "123456", 100));

            Console.WriteLine(testCalls.getHistoryToString());

            Console.Write("Price for all calls (0 sec, 500 sec, 100 sec) * 0.37 lv/min : ");
            Console.WriteLine(testCalls.CalcPrice());

            testCalls.RemoveLongestCall();

            Console.Write("Price for remaining calls (0 sec, 100 sec) * 0.37 lv/min : ");
            Console.WriteLine(testCalls.CalcPrice());
            Console.WriteLine();

            testCalls.ClearCallHistory();
        }
    }
}
