using Dort.Repository.GoogleBook;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dort.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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