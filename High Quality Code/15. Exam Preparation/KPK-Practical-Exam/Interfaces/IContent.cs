namespace Catalog.Interfaces
{
    using System;
    using Catalog.Enumerations;

    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        long Size { get; set; }

        string URL { get; set; }

        ContentType Type { get; set; }

        string TextRepresentation { get; set; }
    }
}
