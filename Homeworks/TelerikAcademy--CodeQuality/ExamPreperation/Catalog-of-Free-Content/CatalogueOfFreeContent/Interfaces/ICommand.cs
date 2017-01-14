namespace CatalogueOfFreeContent.Interfaces
{
    using CatalogueOfFreeContent.Enumerations;

    public interface ICommand
    {
        string Name { get; set; }

        string OriginalForm { get; set; }

        string[] Parameters { get; set; }

        ExistingCommandType Type { get; set; }

        ExistingCommandType ParseCommandType();

        string ParseName(string originalForm);

        string[] ParseParameters(string originalForm);
    }
}