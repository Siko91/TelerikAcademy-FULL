using CalendarSystem.Interfaces;
using System;

namespace CalendarSystem.Classes
{
    public class Event : IComparable<IEvent>, IEvent
    {
        private DateTime date;
        private string location;
        private string title;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public Event(DateTime date, string title)
            : this(date, title, null)
        {
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (null == value)
                {
                    this.date = value;
                }
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.location = value;
                }
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.title = value;
                }
            }
        }

        public int CompareTo(IEvent x)
        {
            // removed a bottleneck! It was very stupid.
            if (DateTime.Compare(this.Date, x.Date) != 0)
            {
                return DateTime.Compare(this.Date, x.Date);
            }
            else if (string.Compare(this.Title, x.Title, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Title, x.Title, StringComparison.Ordinal);
            }
            else if (string.Compare(this.Location, x.Location, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Location, x.Location, StringComparison.Ordinal);
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }
    }
}