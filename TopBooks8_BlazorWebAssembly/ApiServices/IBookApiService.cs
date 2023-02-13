using TopBooks8_Shared;

namespace TopBooks8_BlazorWebAssembly.ApiServices
{
    public interface IBookApiService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book?> Add(Book book);
    }
}
