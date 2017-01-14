using System;
using System.Linq;
using System.Text;

class Event : IComparable
{
    public DateTime Date;
    public String Title;
    public String Location;

    public Event(DateTime date, String title, String location)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int byDate = this.Date.CompareTo(other.Date);
        int byTitle = this.Title.CompareTo(other.Title);
        int byLocation = this.Location.CompareTo(other.Location);

        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(Date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + Title);

        if (Location != null && Location != string.Empty)
        {
            toString.Append(" | " + Location);
        }

        return toString.ToString();
    }
}