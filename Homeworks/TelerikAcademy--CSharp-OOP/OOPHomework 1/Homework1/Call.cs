using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    public class Call
    {
        private DateTime dateAndTime;
        private string dialedPhoneNumber;
        private uint duration;

        public Call(string dialedPhoneNumber)
        {
            if (String.IsNullOrWhiteSpace(dialedPhoneNumber))
            { throw new ArgumentException("Dialed Phone Number can not be null, empty, or white space."); }
            for (int i = 0; i < dialedPhoneNumber.Length; i++)
            {
                if (!char.IsDigit(dialedPhoneNumber[i]))
                { throw new ArgumentException("Dialed Phone Number can only contain digits."); }
            }

            this.dateAndTime = DateTime.Now;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = 0;
        }
        public Call(DateTime dateAndTime, string dialedPhoneNumber, uint duration)
        {
            if (String.IsNullOrWhiteSpace(dialedPhoneNumber))
            { throw new ArgumentException("Dialed Phone Number can not be null, empty, or white space."); }
            for (int i = 0; i < dialedPhoneNumber.Length; i++)
            {
                if (!char.IsDigit(dialedPhoneNumber[i]))
                { throw new ArgumentException("Dialed Phone Number can only contain digits."); }
            }

            this.dateAndTime = dateAndTime;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = duration;
        }
        public uint Duration
        {
            get { return this.duration; }
        }
        public string DialedPhoneNumber
        {
            get { return this.dialedPhoneNumber; }
        }
        public DateTime DateAndTime
        {
            get { return this.dateAndTime; }
        }
    }
}
