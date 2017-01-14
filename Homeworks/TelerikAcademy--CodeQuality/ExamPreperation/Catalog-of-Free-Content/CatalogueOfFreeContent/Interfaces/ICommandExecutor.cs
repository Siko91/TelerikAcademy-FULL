namespace CatalogueOfFreeContent.Interfaces
{
    using System.Text;

    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, IContentFactory contentFactory, StringBuilder output);
    }
}