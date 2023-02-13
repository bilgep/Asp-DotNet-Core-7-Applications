using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopBooks2.Data;

namespace TopBooks2.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IBookRepository _bookRepository;
        public CreateBookModel(ILogger<IndexModel> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [BindProperty]
        public Book NewBookToAdd { get; set; } = new();
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }

            _logger.LogInformationX();
            await _bookRepository.Add(NewBookToAdd);
            return RedirectToPage("Index");
        }
    }
}
