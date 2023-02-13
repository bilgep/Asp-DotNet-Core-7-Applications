using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using TopBooks2.Data;

namespace TopBooks2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IBookRepository _bookRepository;
        public IndexModel(ILogger<IndexModel> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> PageBooks { get; set; } = Enumerable.Empty<Book>();


        public async Task OnGetAsync()
        {
            _logger.LogInformationX();

            PageBooks = await _bookRepository.GetAll();
        }

    }

    public static class X
    {
        public static void LogInformationX(this ILogger<IndexModel> logger)
        {
            logger.LogInformation($"Called at {DateTime.Now}");
        }
    }
}