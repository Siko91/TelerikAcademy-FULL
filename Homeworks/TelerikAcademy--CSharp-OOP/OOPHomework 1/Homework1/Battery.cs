using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    public static class BatteryType
    {
        public static Battery Type1 = new Battery("Type1", 10, 5);
        public static Battery Type2 = new Battery("Type2", 15, 7);
        public static Battery Type3 = new Battery("Type3", 7, 3);
    }

    public class Battery
    {
        private readonly string model;
        private readonly double hoursIdle;
        private readonly double hoursTalk;

        public Battery(string model, double hoursIdle, double hoursTalk)
        {
            if (String.IsNullOrWhiteSpace(model))
            { throw new ArgumentException("Field model can not be null, empty or white space."); }
            if (hoursTalk <= 0)
	        { throw new ArgumentException("Field hoursTalk must be a positive number"); }
            if (hoursIdle < hoursTalk)
            { throw new ArgumentException("Field hoursIdle must be a positive number, equal or bigger than field hoursTalk"); }

            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public string Model
        {
            get { return this.model; }
        }
        public double HoursIdle
        {
            get { return this.hoursIdle; }
        }
        public double HoursTalk
        {
            get { return this.hoursTalk; }
        }
    }
}
