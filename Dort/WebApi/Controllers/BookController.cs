using Dort.Repository.GoogleBook;
using Dort.WebApi.Models;
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
        public async Task<ActionResult<RequestResponse>> FindByName([FromQuery]string name)
        {
            var response = await _bookRepository.FindByBookName(name);
            return Ok(new RequestResponse() { Content = response });
        }

        [HttpGet]
        public async Task<ActionResult<RequestResponse>> FindBy([FromQuery]string name)
        {
            var response = await _bookRepository.FindByBookName(name);
            return Ok(new RequestResponse() { Content = response });
        }
    }
}