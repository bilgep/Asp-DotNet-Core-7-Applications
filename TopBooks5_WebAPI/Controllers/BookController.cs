using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopBooks5_Shared;
using TopBooks5_WebAPI.Data;

namespace TopBooks5_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<Book> _logger;
        private readonly IBookRepository _repo;

        public BookController(ILogger<Book> logger, IBookRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _repo.GetAll();
            if (books.Count() == 0)
            { 
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookAsync(int id)
        {
            var book = await _repo.GetBook(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(Book newBook)
        { 
            if(newBook == null)
            {
                return BadRequest();
            }

            await _repo.Add(newBook);

            return Ok(newBook);
        }
    }
}
