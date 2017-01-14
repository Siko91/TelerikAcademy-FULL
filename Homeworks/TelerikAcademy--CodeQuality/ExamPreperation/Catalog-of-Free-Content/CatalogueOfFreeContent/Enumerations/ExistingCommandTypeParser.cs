namespace CatalogueOfFreeContent.Enumerations
{
    using System;

    public class ExistingCommandTypeParser
    {
        public ExistingCommandType Parse(string commandName)
        {
            switch (commandName)
            {
                case "Add book": return ExistingCommandType.AddBook;
                case "Add movie": return ExistingCommandType.AddMovie;
                case "Add song": return ExistingCommandType.AddSong;
                case "Add application": return ExistingCommandType.AddApplication;
                case "Update": return ExistingCommandType.Update;
                case "Find": return ExistingCommandType.Find;
                default: throw new ArgumentException("Invalid command Name");
            }
        }
    }
}