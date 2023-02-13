using System.Net.Http.Json;
using TopBooks5_Shared;

namespace TopBooks5_BlazorWebAssmbly.ApiServices
{
    public class BookApiService : IBookApiService
    {
        private readonly HttpClient _httpClient;

        public BookApiService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var response = await _httpClient.GetAsync("Book");
            //response.EnsureSuccessStatusCode();

            var books = await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();
            if(books == null) return Enumerable.Empty<Book>();

            return books;  
        }

        public async Task<Book> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/Book/{id}/");
            //response.EnsureSuccessStatusCode(); 

            var book = await response.Content.ReadFromJsonAsync<Book>();
            if (book == null) return new();
            return book;
        }

        public async Task<Book?> Add(Book book)
        {
            var jsonContent = JsonContent.Create(book);
            var response = await _httpClient.PostAsync("Book", jsonContent);
            //response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Book>();
        }




    }
}
