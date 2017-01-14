using CalendarSystem.Interfaces;
using System;
using System.Collections.Generic;

namespace CalendarSystem.Classes
{
    public class Command : ICommand
    {
        private string commandName;
        private IList<string> parameters;

        public Command(string commandString)
        {
            int indexOfSpace = commandString.IndexOf(' ');
            if (indexOfSpace == -1)
            {
                throw new Exception(string.Format("Invalid command: {0}", commandString));
            }

            string name = commandString.Substring(0, indexOfSpace);
            string argumentString = commandString.Substring(indexOfSpace + 1);

            var commandArguments = argumentString.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                // Removed a bottle neck - "argumentString = commandArguments[i]"
                commandArguments[i] = commandArguments[i].Trim();
            }

            // Not sure if this works
            new Command(name, commandArguments);
        }

        public Command(string name, IList<string> parameters)
        {
            this.CommandName = name;
            this.Parameters = parameters;
        }

        public string CommandName
        {
            get
            {
                return this.commandName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Command must have a name");
                }

                this.commandName = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            set
            {
                if (value.Count < 1)
                {
                    throw new ArgumentException("Command must have parameters");
                }

                this.parameters = value;
            }
        }
    }
}