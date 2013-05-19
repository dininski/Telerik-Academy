using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Catalog.Interfaces
{
    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, Int32 numberOfContentElementsToList);

        Int32 UpdateContent(string oldUrl, string newUrl);
    }
}
