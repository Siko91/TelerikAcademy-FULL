using System;
using System.Globalization;
using System.Linq;
using System.Text;
using CalendarSystem.Interfaces;

namespace CalendarSystem.Classes
{
    public class CommandManager : ICommandManager
    {
        private IEventManager eventManager;

        public CommandManager(IEventManager eventManager)
        {
            this.EventManager = eventManager;
        }

        public IEventManager EventManager
        {
            get
            {
                return this.eventManager;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("EventManager can not be null");
                }

                this.eventManager = value;
            }
        }

        public string ProcessCommand(ICommand command)
        {
            if (command.CommandName == "AddEvent")
            {
                return this.ExecuteAddEventCommand(command);
            }
            else if (command.CommandName == "DeleteEvents")
            {
                return this.ExecuteDeleteCommand(command);
            }
            else if (command.CommandName == "ListEvents")
            {
                return this.ExecuteListCommand(command);
            }
            else
            {
                throw new ArgumentException(string.Format("Unrecognised command: {0}", command.CommandName));
            }
        }

        private string ExecuteAddEventCommand(ICommand command)
        {
            var date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            IEvent newEvent;
            if (command.Parameters.Count == 2)
            {
                newEvent = new Event(date, command.Parameters[1]);
            }
            else if (command.Parameters.Count == 3)
            {
                newEvent = new Event(date, command.Parameters[1], command.Parameters[2]);
            }
            else
            {
                throw new ArgumentException("Can not create event with this parameters");
            }

            this.EventManager.AddEvent(newEvent);

            return "Event added";
        }

        private string ExecuteDeleteCommand(ICommand command)
        {
            int countOfDeleted = 0;
            if (command.Parameters.Count == 1)
            {
                countOfDeleted = this.EventManager.DeleteEventsByTitle(command.Parameters[0]);
            }
            else
            {
                throw new ArgumentException("Can not delete events  with this parameters");
            }

            if (countOfDeleted == 0)
            {
                return "No events found.";
            }
            else
            {
                return string.Format("{0} events deleted", countOfDeleted);
            }
        }

        private string ExecuteListCommand(ICommand command)
        {
            if (command.Parameters.Count == 2)
            {
                var date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var count = int.Parse(command.Parameters[1]);

                // bottleneck - unneeded .ToList()
                var events = this.EventManager.ListEvents(date, count);

                if (!events.Any())
                {
                    return "No events found";
                }

                var sb = new StringBuilder();
                foreach (var ev in events)
                {
                    sb.AppendLine(ev.ToString());
                }

                // bottleneck - no trimming is neaded
                return sb.ToString();
            }
            else
            {
                throw new ArgumentException("Can not list events with this parameters");
            }
        }
    }
}