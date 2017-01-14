namespace Computers.Client
{
    using System;
    using System.Collections.Generic;
    using Computers.Core.Computers;
    using Computers.Core.Interfaces;
    using Computers.Core.Manufacrorers;

    internal class ConsoleClient
    {
        public ConsoleClient() : this(new List<string>())
        {
        }

        public ConsoleClient(List<string> commandsList)
        {
            this.Commands = commandsList;
            string manufacturerString = Console.ReadLine().ToLower();
            if (manufacturerString == "hp")
            {
                this.Manufacturer = new Hp();
            }
            else if (manufacturerString == "dell")
            {
                this.Manufacturer = new Dell();
            }
            else if (manufacturerString == "lenovo")
            {
                this.Manufacturer = new Lenovo();
            }
            else
            {
                throw new ArgumentException("invalid manufacturer!");
            }
        }

        public IList<string> Commands { get; set; }

        public IManufacturer Manufacturer { get; set; }

        public void Run()
        {
            this.ReadCommands();
            this.ExecuteCommands();
        }

        private void Charge(int num)
        {
            LapTop laptop = (LapTop)this.Manufacturer.LapTop;
            laptop.Battery.Charge(num);

            laptop.MotherBoard.Draw(string.Format("Battery status: {0}%", laptop.Battery.Percentage));
        }

        private void ExecuteCommands()
        {
            foreach (string command in this.Commands)
            {
                string[] commandParameters = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException("invalid command!");
                    }
                }

                string commandName = commandParameters[0];
                
                int commandParam = 0;
                if (!int.TryParse(commandParameters[1], out commandParam))
                {
                    throw new ArgumentException(string.Format("Command Parameter must be a number: {0}", command));
                }

                if (commandName == "charge")
                {
                    this.Charge(commandParam);
                }
                else if (commandName == "process")
                {
                    this.Process(commandParam);
                }
                else if (commandName == "play")
                {
                    this.Play(commandParam);
                }
            }
        }

        private void Play(int num)
        {
            Pc pc = (Pc)this.Manufacturer.Pc;
            pc.MotherBoard.Draw(pc.Play(num));
        }

        private void Process(int num)
        {
            Server pc = (Server)this.Manufacturer.Server;
            pc.MotherBoard.Draw(pc.MotherBoard.Cpu.SquareNumber(num));
        }

        private void ReadCommands()
        {
            while (true)
            {
                var command = Console.ReadLine().ToLower();
                if (command == null)
                {
                    break;
                }

                if (command.StartsWith("exit"))
                {
                    break;
                }

                this.Commands.Add(command);
            }
        }
    }
}