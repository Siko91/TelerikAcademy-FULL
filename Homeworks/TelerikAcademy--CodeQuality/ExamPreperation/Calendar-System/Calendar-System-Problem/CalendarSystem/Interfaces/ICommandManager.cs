using System;
using System.Linq;

namespace CalendarSystem.Interfaces
{
    public interface ICommandManager
    {
        IEventManager EventManager { get; set; }

        string ProcessCommand(ICommand com);
    }
}