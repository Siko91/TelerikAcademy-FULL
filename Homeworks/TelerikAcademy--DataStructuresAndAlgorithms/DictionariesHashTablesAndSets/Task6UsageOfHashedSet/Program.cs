using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6UsageOfHashedSet
{
    internal class Program
    {
        internal struct Command
        {
            internal IList<string> args;
            internal string name;
        }

        private static void DisplayHumans(ICollection<Human> collection)
        {
            foreach (Human h in collection)
            {
                Console.WriteLine(h);
            }
        }

        private static void ExecuteCommand(Command command, PhoneBook phoneBook)
        {
            if (command.name.ToLowerInvariant().Equals("find"))
            {
                if (command.args.Count() == 1)
                {
                    Console.WriteLine(" ---- Find(" + command.args[0] + ") ---- ");
                    ICollection<Human> filteredByName = phoneBook.FindByName(command.args[0]);
                    DisplayHumans(filteredByName);
                }
                else if (command.args.Count() == 2)
                {
                    Console.WriteLine(" ---- Find(" + command.args[0] + ", " + command.args[1] + ") ---- ");
                    ICollection<Human> filteredByNameAndTown = phoneBook.FindByNameAndTown(command.args[0], command.args[1]);
                    DisplayHumans(filteredByNameAndTown);
                }
            }
            else
            {
                throw new ArgumentException("Unknown command '" + command.name + "'");
            }
        }

        private static void Main(string[] args)
        {
            PhoneBook phoneBook = ParsePhoneBook("..\\..\\input.txt");
            ICollection<Command> commands = ReadCommands("..\\..\\commands.txt");

            foreach (var command in commands)
            {
                ExecuteCommand(command, phoneBook);
            }
        }

        private static IList<string> MakeCommandArgumentsCollection(string[] partsOfLine)
        {
            List<string> result = new List<string>();
            for (int i = 1; i < partsOfLine.Length; i++)
            {
                result.Add(partsOfLine[i]);
            }
            return result;
        }

        private static PhoneBook ParsePhoneBook(string filePath)
        {
            PhoneBook book = new PhoneBook();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var partsOfLine = line.Split('|').Select(str => str.Trim()).ToArray();
                    if (partsOfLine.Count() != 3)
                    {
                        var ioe = new IOException("invalid line in the text file : " + line);
                        throw ioe;
                    }
                    book.Records.Add(new Human()
                    {
                        Name = partsOfLine[0],
                        Town = partsOfLine[1],
                        PhoneNumber = partsOfLine[2]
                    });
                    line = reader.ReadLine();
                }
            }
            return book;
        }

        private static ICollection<Command> ReadCommands(string filePath)
        {
            List<Command> commands = new List<Command>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var partsOfLine = line
                        .Split(
                            new char[] { ',', '(', ')' },
                            StringSplitOptions.RemoveEmptyEntries)
                        .Select(str =>
                            str.Trim())
                        .ToArray();

                    var com = new Command()
                    {
                        name = partsOfLine[0],
                        args = MakeCommandArgumentsCollection(partsOfLine)
                    };
                    commands.Add(com);
                    line = reader.ReadLine();
                }
            }
            return commands;
        }
    }
}