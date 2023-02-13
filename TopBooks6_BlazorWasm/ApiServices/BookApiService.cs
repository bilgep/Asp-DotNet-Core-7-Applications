using System.Net.Http.Json;
using TopBooks6_Shared;

namespace TopBooks6_BlazorWasm.ApiServices
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
            var response = await httpClient.PostAsync("book", bookJson);
            return await response.Content.ReadFromJsonAsync<Book?>();
            
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var response = await httpClient.GetAsync("book");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();
        }

        public async Task<Book> GetById(int id)
        {
            var response = await httpClient.GetAsync($"book/{id}");
            return await response.Content.ReadFromJsonAsync<Book>();
        }
    }
}
