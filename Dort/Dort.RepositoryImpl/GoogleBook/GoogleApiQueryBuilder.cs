using Dort.Enum;
using Dort.Enum.GoogleBooksApiEnum;
using Dort.Repository.GoogleBook;
using System.Text;

namespace Dort.RepositoryImpl.GoogleBook
{
    public class GoogleApiQueryBuilder : IGoogleApiQueryBuilder
    {
        private string _title;
        private string _author;
        private string _publisher;
        private string _subject;
        private string _volumeId;
        private int _startIndex;
        private int _maxResults;
        private PrintType? _printType;
        private Projection? _projection;
        private Sorting? _orderBy;

        private const int START_INDEX_DEFAULT_VALUE = 0;
        private const int MAX_RESULTS_DEFAULT_VALUE = 10;

        public GoogleApiQueryBuilder()
        {
            _startIndex = START_INDEX_DEFAULT_VALUE;
            _maxResults = MAX_RESULTS_DEFAULT_VALUE;
        }

        public IGoogleApiQueryBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public IGoogleApiQueryBuilder SetAuthor(string author)
        {
            _author = author;
            return this;
        }

        public IGoogleApiQueryBuilder SetPublisher(string publisher)
        {
            _publisher = publisher;
            return this;
        }

        public IGoogleApiQueryBuilder SetVolumeId(string volumeId)
        {
            _volumeId = volumeId;
            return this;
        }

        public IGoogleApiQueryBuilder SetSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public IGoogleApiQueryBuilder SetStartIndex(int startIndex)
        {
            if (startIndex >= 0)
                _startIndex = startIndex;

            return this;
        }

        public IGoogleApiQueryBuilder SetMaxResults(int maxResults)
        {
            if (maxResults <= 40 && maxResults > 0)
                _maxResults = maxResults;

            return this;
        }

        public IGoogleApiQueryBuilder SetPrintType(PrintType? printType)
        {
            _printType = printType;
            return this;
        }

        public IGoogleApiQueryBuilder AddTitle(string title)
        {
            _title = title;
            return this;
        }

        public IGoogleApiQueryBuilder SetProjection(Projection? projection)
        {
            _projection = projection;
            return this;
        }

        public IGoogleApiQueryBuilder SetOrderBy(Sorting? orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public string BuildQueryString()
        {
            StringBuilder builder = new StringBuilder();

            AppendIfExistis(builder, Parameters.Intitle, _title);
            AppendIfExistis(builder, Parameters.Inauthor, _author);
            AppendIfExistis(builder, Parameters.InPublisher, _publisher);
            AppendIfExistis(builder, Parameters.Subject, _subject);
            AppendIfExistis(builder, Parameters.VolumeId, _volumeId);

            if (_startIndex != START_INDEX_DEFAULT_VALUE)
                AppendIfExistis(builder, Parameters.StartIndex, _startIndex, '=');

            if(_maxResults != MAX_RESULTS_DEFAULT_VALUE)
                AppendIfExistis(builder, Parameters.MaxResults, _maxResults, '=');

            if (_printType.HasValue)
                AppendIfExistis(builder, Parameters.PrintType, _printType.Value.Description(), '=');

            if (_projection.HasValue)
                AppendIfExistis(builder, Parameters.Projection, _projection.Value.Description(), '=');

            if (_orderBy.HasValue)
                AppendIfExistis(builder, Parameters.OrderBy, _orderBy.Value.Description(), '=');

            return builder.ToString();
        }

        private void AppendIfExistis(StringBuilder builder, string paramName, object value, char separator = ':')
        {
            if (value != null)
            {
                if (!string.IsNullOrEmpty(builder.ToString()))
                {
                    builder.Append("&");
                }

                builder.Append($"{paramName}{separator}{value}");
            }
        }
    }
}
