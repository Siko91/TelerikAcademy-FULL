namespace CatalogueOfFreeContent
{
    using CatalogueOfFreeContent.Enumerations;
    using CatalogueOfFreeContent.Interfaces;

    public class ContentFactory : IContentFactory
    {
        public IContent CreateApplication(ICommand command)
        {
            return new Content(ContentType.Application, command.Parameters);
        }

        public IContent CreateBook(ICommand command)
        {
            return new Content(ContentType.Book, command.Parameters);
        }

        public IContent CreateMovie(ICommand command)
        {
            return new Content(ContentType.Movie, command.Parameters);
        }

        public IContent CreateSong(ICommand command)
        {
            return new Content(ContentType.Song, command.Parameters);
        }
    }
}