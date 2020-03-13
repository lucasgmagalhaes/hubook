using Dort.Enum.GoogleBooksApiEnum;

namespace Dort.Repository.GoogleBook
{
    public interface IGoogleApiQueryBuilder
    {
        IGoogleApiQueryBuilder SetTitle(string title);
        IGoogleApiQueryBuilder SetAuthor(string author);
        IGoogleApiQueryBuilder SetPublisher(string publisher);
        IGoogleApiQueryBuilder SetVolumeId(string volumeId);
        IGoogleApiQueryBuilder SetSubject(string subject);
        IGoogleApiQueryBuilder SetStartIndex(int startIndex);
        IGoogleApiQueryBuilder SetMaxResults(int maxResults);
        IGoogleApiQueryBuilder SetPrintType(PrintType? printType);
        IGoogleApiQueryBuilder AddTitle(string title);
        IGoogleApiQueryBuilder SetProjection(Projection? projection);
        IGoogleApiQueryBuilder SetOrderBy(Sorting? orderBy);
        string BuildQueryString();
    }
}
