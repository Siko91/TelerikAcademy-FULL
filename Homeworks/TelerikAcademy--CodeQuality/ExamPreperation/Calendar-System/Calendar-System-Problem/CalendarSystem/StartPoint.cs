using CalendarSystem.Classes;
using CalendarSystem.Interfaces;
using System;

namespace CalendarSystem
{
    internal class StartPoint
    {
        internal static void Main()
        {
            var eventManager = new EventManagerFast();
            var commandManager = new CommandManager(eventManager);
            string commandLine = Console.ReadLine();

            while (commandLine != "End")
            {
                try
                {
                    ICommand command = new Command(commandLine);
                    Console.WriteLine(commandManager.ProcessCommand(command));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}