using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Homework3
{
    public delegate void DoAction(string str);

    public class DemoOfTimers
    {
        public static void Demo()
        {
            DoAction printMsg = PrintMsg;

            Timer t1 = new Timer(DateTime.Now, DateTime.Now.AddSeconds(1), 50, printMsg, "Timer 1 - First Event");
            Timer t2 = new Timer(DateTime.Now, DateTime.Now.AddSeconds(1), 60, printMsg, "Timer 2 - Second Event");

            Console.WriteLine("------------------\nTask 7\n");

            while (t1.done == false || t2.done == false)
            {
                t1.CheckTimer();
                t2.CheckTimer();

                Thread.Sleep(30);
                printMsg("Thread has slept, but the timers will work normaly.");
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Press [Enter] to continue with the demos.");
            Console.ReadLine();
            return;
        }
        public static void PrintMsg(string str)
        {
            Console.WriteLine(str);
        }
    }
}
