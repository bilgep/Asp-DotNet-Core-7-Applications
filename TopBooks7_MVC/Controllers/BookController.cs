using Microsoft.AspNetCore.Mvc;
using TopBooks7_gRPC;
using static TopBooks7_gRPC.Books;

namespace TopBooks7_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BooksClient booksClient;

        public BookController(BooksClient booksClient)
        {
            this.booksClient = booksClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await booksClient.GetAllAsync( new TopBooks7_gRPC.AllBooksRequest());
            return View(response.Books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {

            if(!ModelState.IsValid) return View();

            await booksClient.CreateNewAsync(new CreateNewBookRequest{ Book = book });

            return RedirectToAction("Index");
        }
    }
}
