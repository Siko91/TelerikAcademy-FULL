namespace CatalogueOfFreeContent
{
    using CatalogueOfFreeContent.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleClient
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalogue = new Catalog();
            ICommandExecutor executor = new CommandExecutor();
            IContentFactory contentFactory = new ContentFactory();

            foreach (ICommand item in ReadAllCommands(true))
            {
                executor.ExecuteCommand(catalogue, item, contentFactory, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadAllCommands()
        {
            List<ICommand> commands = new List<ICommand>();

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine.Trim() != "End")
                {
                    commands.Add(new Command(inputLine));
                }
                else
                {
                    break;
                }
            }

            return commands;
        }

        private static List<ICommand> ReadAllCommands(bool testing)
        {
            List<ICommand> commands = new List<ICommand>();

            List<string> lines = new List<string>() { "Find: One; 3",
                "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org",
                "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info",
                "Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs",
                "Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d",
                "Find: One; 1",
                "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/",
                "Find: One; 10",
                "Update: http://www.introprogramming.info; http://introprograming.info/en/",
                "Find: Intro C#; 1",
                "Update: http://nakov.com; sftp://www.nakov.com",
                "End"
            };

            foreach (string inputLine in lines)
            {
                Console.WriteLine(inputLine);
                if (inputLine.Trim() != "End")
                {
                    commands.Add(new Command(inputLine));
                }
                else
                {
                    break;
                }
            }
            return commands;
        }
    }
}