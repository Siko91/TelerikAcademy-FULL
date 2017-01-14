using CalendarSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CalendarSystem.Classes
{
    public class EventManagerFast : IEventManager
    {
        private OrderedMultiDictionary<DateTime, IEvent> eventsByDates = new OrderedMultiDictionary<DateTime, IEvent>(true);
        private MultiDictionary<string, CalendarSystem.Interfaces.IEvent> eventsByTitles = new MultiDictionary<string, CalendarSystem.Interfaces.IEvent>(true);

        public OrderedMultiDictionary<DateTime, IEvent> EventsByDates
        {
            get
            {
                return this.eventsByDates;
            }

            set
            {
                this.eventsByDates = value;
            }
        }

        public MultiDictionary<string, IEvent> EventsByTitles
        {
            get
            {
                return this.eventsByTitles;
            }

            set
            {
                this.eventsByTitles = value;
            }
        }

        public void AddEvent(IEvent newEvent)
        {
            string eventTitleLowerCase = newEvent.Title.ToLowerInvariant();
            this.EventsByTitles.Add(eventTitleLowerCase, newEvent);
            this.EventsByDates.Add(newEvent.Date, newEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            title = title.ToLowerInvariant();
            var eventsToDelete = this.EventsByTitles[title];
            int countx = eventsToDelete.Count;

            foreach (var ev in eventsToDelete)
            {
                this.EventsByDates.Remove(ev.Date, ev);
            }

            this.EventsByTitles.Remove(title);

            return countx;
        }

        public IEnumerable<IEvent> ListEvents(DateTime date, int count)
        {
            var da = this.EventsByDates.RangeFrom(date, true).Values;
            var events = da.Take(count);
            return events;
        }
    }
}