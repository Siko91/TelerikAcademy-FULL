namespace CatalogueOfFreeContent.Testing.TestsData
{
    public class CommandTestsData
    {
        public const string CommandName = "Add book";
        public const string SingleParamOfCommand = "Param 1";
        public static string[] FullParamsOfCommand = { "Param 1", "Param 2", "Param 3", "Param 4" };
        public Command Command;

        public CommandTestsData()
        {
            this.Command = this.CreateCommand();
        }

        public Command CreateCommand()
        {
            return new Command(CommandName + ": " + string.Join("; ", FullParamsOfCommand));
        }

        public Command CreateCommand(string str)
        {
            return new Command(str);
        }
    }
}