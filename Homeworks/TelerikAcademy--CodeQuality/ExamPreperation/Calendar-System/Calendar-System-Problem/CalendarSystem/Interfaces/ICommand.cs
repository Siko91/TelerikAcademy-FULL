using System;
using System.Collections.Generic;

namespace CalendarSystem.Interfaces
{
    public interface ICommand
    {
        string CommandName { get; set; }

        IList<string> Parameters { get; set; }
    }
}