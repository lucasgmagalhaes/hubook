namespace Dort.Entity.GoogleBook
{
    public abstract class QueryFilter
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Subject { get; set; }

        public QueryFilter(string? title, string? author, string? publisher, string? subject)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Subject = subject;
        }
    }
}
