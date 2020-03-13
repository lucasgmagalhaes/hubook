using System.ComponentModel;

namespace Dort.Enum.GoogleBooksApiEnum
{
    /// <summary>
    /// Restrict the returned results to a specific print or publication type
    /// </summary>
    public enum PrintType
    {
        /// <summary>
        /// Does not restrict by print type (default)
        /// </summary>
        [Description("all")]
        ALL,
        /// <summary>
        /// Returns only results that are books.
        /// </summary>
        [Description("books")]
        BOOKS,
        /// <summary>
        /// Returns results that are magazines.
        /// </summary>
        [Description("magazines")]
        MAGAZINES
    }

    /// <summary>
    ///  specify a predefined set of Volume fields to return
    /// </summary>
    public enum Projection
    {
        /// <summary>
        /// Returns all Volume fields.
        /// </summary>
        [Description("full")]
        FULL,
        /// <summary>
        /// Returns only certain fields. See field descriptions marked with double asterisks in the Volume reference to find out which fields are included.
        /// <see cref="https://developers.google.com/books/docs/v1/reference#resource_volumes"/>
        /// </summary>
        [Description("lite")]
        LITE
    }

    /// <summary>
    /// By default, a volumes search request returns maxResults results, where maxResults
    /// is the parameter used in pagination (above), ordered by relevance to search terms
    /// </summary>
    public enum Sorting
    {
        /// <summary>
        /// Returns results in order of the relevance of search terms (this is the default).
        /// </summary>
        [Description("relevance")]
        RELEVANCE,
        /// <summary>
        /// Returns results in order of most recently to least recently published.
        /// </summary>
        [Description("newest")]
        NEWEST
    }
}
