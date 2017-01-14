namespace CatalogueOfFreeContent.Interfaces
{
    public interface IContentFactory
    {
        IContent CreateApplication(ICommand command);

        IContent CreateBook(ICommand command);

        IContent CreateMovie(ICommand command);

        IContent CreateSong(ICommand command);
    }
}