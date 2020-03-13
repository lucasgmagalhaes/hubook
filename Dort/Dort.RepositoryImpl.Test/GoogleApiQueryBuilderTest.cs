using Dort.Enum;
using Dort.Enum.GoogleBooksApiEnum;
using Dort.Repository.GoogleBook;
using Dort.RepositoryImpl.GoogleBook;
using NUnit.Framework;

namespace Dort.RepositoryImpl.Test
{
    public class GoogleApiQueryBuilderTest
    {
        private const string _title = "DartTower";
        private const string _author = "Stephen King";
        private const string _publisher = "Anyone";
        private const string _subject = "A lot of things";
        private const string _volumeId = "Aclask_Aaeaef12";
        private const int _startIndex = 1;
        private const int _maxResults = 11;
        private const PrintType _printType = PrintType.BOOKS;
        private const Projection _projection = Projection.FULL;
        private const Sorting _orderBy = Sorting.RELEVANCE;

        private IGoogleApiQueryBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new GoogleApiQueryBuilder();
        }

        [Test]
        public void ShouldReturnOkWithOneParameter()
        {
            _builder.SetAuthor(_author);
            Assert.AreEqual($"{Parameters.Inauthor}:{_author}", _builder.BuildQueryString());
        }

        [Test]
        public void ShouldAddSeparatorForMultiplesParameters()
        {
            _builder.SetAuthor(_author)
                    .SetPublisher(_publisher);

            var query = _builder.BuildQueryString();

            StringAssert.Contains("&", query);
        }

        [Test]
        public void ShouldSetdexZeroIfValueIsLowerThanZero()
        {
            var query = _builder
                .SetStartIndex(-1)
                .BuildQueryString();

            Assert.AreEqual(string.Empty, query);
        }

        [Test]
        public void ShouldSetMaxResults40IfValueIsGreaterThan40()
        {
            var query = _builder
                .SetMaxResults(41)
                .BuildQueryString();

            Assert.AreEqual(string.Empty, query);
        }

        [Test]
        public void ShouldSetMaxResults1IfValueIsLowerThan1()
        {
            var query = _builder.
                SetMaxResults(0)
                .BuildQueryString();

            Assert.AreEqual(string.Empty, query);
        }

        [Test]
        public void ShouldCreateQueryOk()
        {
            _builder.SetTitle(_title)
                .SetAuthor(_author)
                .SetPublisher(_publisher)
                .SetSubject(_subject)
                .SetVolumeId(_volumeId)
                .SetMaxResults(_maxResults)
                .SetProjection(_projection)
                .SetStartIndex(_startIndex)
                .SetPrintType(_printType)
                .SetOrderBy(_orderBy);

            var query = _builder.BuildQueryString();

            Assert.AreEqual(10, query.Split('&').Length);

            StringAssert.Contains($"{Parameters.Intitle}:{_title}", query);
            StringAssert.Contains($"{Parameters.Inauthor}:{_author}", query);
            StringAssert.Contains($"{Parameters.InPublisher}:{_publisher}", query);
            StringAssert.Contains($"{Parameters.Subject}:{_subject}", query);
            StringAssert.Contains($"{Parameters.VolumeId}:{_volumeId}", query);
            StringAssert.Contains($"{Parameters.MaxResults}={_maxResults}", query);
            StringAssert.Contains($"{Parameters.Projection}={_projection.Description()}", query);
            StringAssert.Contains($"{Parameters.StartIndex}={_startIndex}", query);
            StringAssert.Contains($"{Parameters.PrintType}={_printType.Description()}", query);
            StringAssert.Contains($"{Parameters.OrderBy}={_orderBy.Description()}", query);
        }
    }
}