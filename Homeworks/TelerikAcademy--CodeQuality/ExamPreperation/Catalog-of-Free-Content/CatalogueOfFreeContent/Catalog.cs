namespace CatalogueOfFreeContent
{
    using CatalogueOfFreeContent.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class Catalog : ICatalog
    {
        private readonly OrderedMultiDictionary<string, IContent> contentByTitle;
        private readonly MultiDictionary<string, IContent> contentByURLs;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.contentByTitle = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.contentByURLs = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.contentByTitle.Add(content.Title, content);
            this.contentByURLs.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = this.contentByTitle[title];

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            IEnumerable<IContent> contentToUpdate = this.contentByURLs[oldUrl].ToList();

            foreach (IContent currentContent in contentToUpdate)
            {
                currentContent.Url = newUrl;
            }

            int countOfChanges = contentToUpdate.Count();

            return countOfChanges;
        }
    }
}