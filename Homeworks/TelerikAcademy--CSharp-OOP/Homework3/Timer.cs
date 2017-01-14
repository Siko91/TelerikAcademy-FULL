using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    public class Timer
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int DoActionEveryMiliseconds { get; set; }
        public bool done = false;
        public DoAction Action { get; set; }
        public int actionDoneTimes = 0;
        public string Message { get; set; }

        public Timer(DateTime Start, DateTime Stop, int DoActionEveryMiliseconds, DoAction Action, string message)
        {
            if (Start > Stop)
            {
                throw new ArgumentException("invalid time period");
            }

            this.Start = Start;
            this.Stop = Stop;
            this.DoActionEveryMiliseconds = DoActionEveryMiliseconds;
            this.Message = message;
            this.Action = Action;
        }
        public void CheckTimer()
        {
            if (done)
            {
                return;
            }
            if (DateTime.Now > Stop)
            {
                this.done = true;
                return;
            }
            if ((DateTime.Now - Start).TotalMilliseconds / DoActionEveryMiliseconds > actionDoneTimes)
            {
                int timesLeft = (int)((DateTime.Now - Start).TotalMilliseconds / DoActionEveryMiliseconds - actionDoneTimes);
                for (int i = 0; i < timesLeft; i++)
                {
                    this.Action(this.Message);
                    this.actionDoneTimes++;
                }
                return;
            }
            else
            {
                return;
            }
        }
    }
}