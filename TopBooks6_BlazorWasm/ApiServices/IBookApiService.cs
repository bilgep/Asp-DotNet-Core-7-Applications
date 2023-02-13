using TopBooks6_Shared;

namespace TopBooks6_BlazorWasm.ApiServices
{
    public interface IBookApiService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book?> Add(Book book);
    }
}
