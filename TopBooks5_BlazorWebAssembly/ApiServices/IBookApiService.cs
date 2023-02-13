using TopBooks5_Shared;

namespace TopBooks5_BlazorWebAssmbly.ApiServices
{
    public interface IBookApiService
    {
        Task<Book?> Add(Book book);
        Task<IEnumerable<Book>> GetAll();    
        Task<Book> GetById(int id);
    }
}
