using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem.Interfaces
{
    public interface IEventManager
    {
        void AddEvent(IEvent newEvent);

        int DeleteEventsByTitle(string title);

        IEnumerable<IEvent> ListEvents(DateTime day, int count);
    }
}