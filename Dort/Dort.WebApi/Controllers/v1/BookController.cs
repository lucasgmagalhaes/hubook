using Dort.Enum.GoogleBooksApiEnum;
using Dort.Repository.GoogleBook;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dort.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        public readonly IGoogleBookRepository _bookRepository;
        public readonly IGoogleApiQueryBuilder _queryBuilder;

        public BookController(IGoogleBookRepository googleBookRepository, IGoogleApiQueryBuilder queryBuilder)
        {
            _bookRepository = googleBookRepository;
            _queryBuilder = queryBuilder;
        }

        [HttpGet]
        public async Task<ActionResult> Find(
            [FromQuery] string title,
            [FromQuery] string author,
            [FromQuery] string publisher,
            [FromQuery] string subject,
            [FromQuery] string volumeId,
            [FromQuery] int maxResults,
            [FromQuery] int startIndex,
            [FromQuery] PrintType printType,
            [FromQuery] Projection projection,
            [FromQuery] Sorting orderBy)
        {

            _queryBuilder
                .SetTitle(title)
                .SetAuthor(author)
                .SetPublisher(publisher)
                .SetSubject(subject)
                .SetVolumeId(volumeId)
                .SetMaxResults(maxResults)
                .SetProjection(projection)
                .SetStartIndex(startIndex)
                .SetPrintType(printType)
                .SetOrderBy(orderBy);

            return Ok(await _bookRepository.FindByFilter(_queryBuilder));
        }

    }
}
