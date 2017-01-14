using System;
using System.Collections.Generic;
using System.Linq;
using CalendarSystem.Interfaces;

namespace CalendarSystem.Classes
{
    public class EventManager : IEventManager
    {
        private List<IEvent> list;

        public EventManager()
        {
            this.List = new List<IEvent>();
        }

        public List<IEvent> List
        {
            get
            {
                return this.list;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentException("Event list can not be null");
                }
                this.list = value;
            }
        }

        public void AddEvent(IEvent newEvent)
        {
            this.List.Add(newEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.List.RemoveAll(
                e => e.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<IEvent> ListEvents(DateTime d, int c)
        {
            List<IEvent> result = this.List.FindAll(e => e.Date >= d);
            result.Sort();
            return result.Take(c);
        }
    }
}