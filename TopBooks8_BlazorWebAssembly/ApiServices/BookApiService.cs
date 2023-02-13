using System.Net.Http.Json;
using TopBooks8_Shared;

namespace TopBooks8_BlazorWebAssembly.ApiServices
{
    public class BookApiService : IBookApiService
    {
        private readonly HttpClient httpClient;

        public BookApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Book?> Add(Book book)
        {
            var bookJson = JsonContent.Create(book);
            var response = await httpClient.PostAsync("books", bookJson);
            return await response.Content.ReadFromJsonAsync<Book?>();
            
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var response = await httpClient.GetAsync("books");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Book>>() ?? Enumerable.Empty<Book>();
        }

        public async Task<Book> GetById(int id)
        {
            var response = await httpClient.GetAsync($"books/{id}");
            return await response.Content.ReadFromJsonAsync<Book>() ?? new();
        }
    }
}
