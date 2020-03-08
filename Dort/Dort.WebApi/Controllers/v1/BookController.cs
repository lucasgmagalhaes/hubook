using Dort.Repository.GoogleBook;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dort.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        public IGoogleBookRepository _bookRepository;

        public BookController(IGoogleBookRepository googleBookRepository)
        {
            _bookRepository = googleBookRepository;
        }

        [HttpGet]
        public async Task<ActionResult> FindByName([FromQuery]string name)
        {
            return Ok(await _bookRepository.FindByBookName(name));
        }
    }
}