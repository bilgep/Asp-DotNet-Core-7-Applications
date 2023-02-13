namespace TopBooks4.Data
{
    public interface IBookRepository
    {
        /// <summary>
        /// Adds new book and returns the newly added book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<Book> Add(Book book);

        /// <summary>
        /// Returns all recorded books 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetAll();

        /// <summary>
        /// Gets one book for the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetBook(int id);

    }
}
