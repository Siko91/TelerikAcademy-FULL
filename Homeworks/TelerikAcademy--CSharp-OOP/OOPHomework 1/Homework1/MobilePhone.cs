using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    public class MobilePhone
    {
        public const string IPhone4S = "I have no idea what is this field about, but I made it cuz the homework said I have to";

        private List<Call> callHistory = new List<Call>();

        private readonly string model;
        private readonly string manufacturer;
        private double price;
        private string owner;

        private readonly Display display;
        private readonly Battery battery;

        // full constructor
        public MobilePhone(string model, string manufacturer, double price, string owner, Display display, Battery battery)
        {
            if (String.IsNullOrWhiteSpace(model))
            { throw new ArgumentException("Field model can not be null, empty, or white space"); }
            if (String.IsNullOrWhiteSpace(manufacturer))
            { throw new ArgumentException("Field manufacturer can not be null, empty, or white space"); }
            if (price < 0)
            { throw new ArgumentException("Field price must be zero or a positive number"); }
            if (String.IsNullOrWhiteSpace(owner))
            { throw new ArgumentException("Field owner can not be null, empty, or white space"); }

            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;

            this.display = display;
            this.battery = battery;
        }
        // constructor without owner
        public MobilePhone(string model, string manufacturer, double price, Display display, Battery battery)
        {
            if (String.IsNullOrWhiteSpace(model))
            { throw new ArgumentException("Field model can not be null, empty, or white space"); }
            if (String.IsNullOrWhiteSpace(manufacturer))
            { throw new ArgumentException("Field manufacturer can not be null, empty, or white space"); }
            if (price < 0)
            { throw new ArgumentException("Field price must be zero or a positive number"); }
            if (String.IsNullOrWhiteSpace(owner))
            { throw new ArgumentException("Field owner can not be null, empty, or white space"); }

            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = null;

            this.display = display;
            this.battery = battery;
        }

        // constructor without price
        public MobilePhone(string model, string manufacturer, string owner, Display display, Battery battery)
        {
            if (String.IsNullOrWhiteSpace(model))
            { throw new ArgumentException("Field model can not be null, empty, or white space"); }
            if (String.IsNullOrWhiteSpace(manufacturer))
            { throw new ArgumentException("Field manufacturer can not be null, empty, or white space"); }
            if (String.IsNullOrWhiteSpace(owner))
            { throw new ArgumentException("Field owner can not be null, empty, or white space"); }

            this.model = model;
            this.manufacturer = manufacturer;
            this.price = 0;
            this.owner = owner;

            this.display = display;
            this.battery = battery;
        }
        
        // constructor without price and owner
        public MobilePhone(string model, string manufacturer, Display display, Battery battery)
        {
            if (String.IsNullOrWhiteSpace(model))
            { throw new ArgumentException("Field model can not be null, empty, or white space"); }
            if (String.IsNullOrWhiteSpace(manufacturer))
            { throw new ArgumentException("Field manufacturer can not be null, empty, or white space"); }

            this.model = model;
            this.manufacturer = manufacturer;
            this.price = 0;
            this.owner = null;

            this.display = display;
            this.battery = battery;
        }

        public double Price
        {
            get { return this.price; }
            set {
                if (value < 0)
                { throw new ArgumentException("Field price must be a positive number"); }
                this.price = value;
            }
        }
        public string Owner
        {
            get {
                if (String.IsNullOrEmpty(this.owner))
                { throw new ArgumentNullException("Field owner is not set yet."); }
                return this.owner;
            }
            set {
                if (String.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("Field owner can not be null, empty, or white space"); }
                this.owner = value;
            }
        }
        public Display Display
        {
            get { return this.display; }
        }
        public Battery Battery
        {
            get { return this.battery; }
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }


        public override string ToString()
        {
            return "Model: " + this.model + "\nManufacturer: " + this.manufacturer +
                "\nPrice: " + this.price + "$\nOwner: " + this.owner +
                "\nDisplay: " + this.display.Width + "x" + this.display.Height + " - " +
                this.display.NumberOfColors + "\nBattery: " + this.battery.Model + ", " +
                this.battery.HoursIdle + " hours idle, " + this.battery.HoursTalk +
                " hours talk";
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }
        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }
        public double CalculatePriceOfCalls(double pricePerMinute)
        {
            ulong minutes = 0;
            double result = 0;

            foreach (Call call in callHistory)
            {
                minutes += call.Duration / 60 + 1;
                result += minutes * pricePerMinute;
            }

            return result;
        }
    }
}
