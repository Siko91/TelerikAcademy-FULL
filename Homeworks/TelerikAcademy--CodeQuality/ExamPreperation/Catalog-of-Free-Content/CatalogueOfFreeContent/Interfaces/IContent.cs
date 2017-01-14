namespace CatalogueOfFreeContent.Interfaces
{
    using System;
    using CatalogueOfFreeContent.Enumerations;

    public interface IContent : IComparable
    {
        string Author { get; set; }

        long Size { get; set; }

        string TextRepresentation { get; set; }

        string Title { get; set; }

        ContentType Type { get; set; }

        string Url { get; set; }
    }
}