using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TopBooks1.Models;
using TopBooks1.Data;

namespace TopBooks1.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _bookRepository.GetAll();
            return View(viewModel);
        }


        public IActionResult  CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _bookRepository.Add(book);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}