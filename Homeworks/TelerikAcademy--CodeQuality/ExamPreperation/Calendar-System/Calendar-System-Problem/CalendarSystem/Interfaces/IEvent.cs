using System;

namespace CalendarSystem.Interfaces
{
    public interface IEvent
    {
        DateTime Date { get; set; }

        string Location { get; set; }

        string Title { get; set; }

        int CompareTo(IEvent x);
    }
}