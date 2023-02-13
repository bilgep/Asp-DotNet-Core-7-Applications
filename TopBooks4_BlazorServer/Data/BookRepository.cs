namespace TopBooks4.Data
{
    public class BookRepository : IBookRepository
    {
        #region Mock Data Preparation
        private List<Book> _books = new(){
            new Book
            {
                Id= 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Price = 300,
                Stock = 2,
                ImageFilePath = "https://images-na.ssl-images-amazon.com/images/I/41xShlnTZTL._SX376_BO1,204,203,200_.jpg"
            },
            new Book
            {
                Id= 2,
                Title = "Design Patterns",
                Author = "Erich Gamma",
                Price = 310,
                Stock = 1,
                ImageFilePath = "https://images-na.ssl-images-amazon.com/images/I/51szD9HC9pL._SX395_BO1,204,203,200_.jpg"
            },
            new Book
            {
                Id= 3,
                Title = "Patterns of Enterprise Application Architecture",
                Author = "Martin Fowler",
                Price = 320,
                Stock = 5,
                ImageFilePath = "https://images-na.ssl-images-amazon.com/images/I/418BWH1NFIL._SX258_BO1,204,203,200_.jpg"
            },
            new Book
            {
                Id= 4,
                Title = "Enterprise Integration Patterns",
                Author = "Gregor Hohpe",
                Price = 330,
                Stock = 4,
                ImageFilePath = "https://images-na.ssl-images-amazon.com/images/I/51pcuI4QqML._SX376_BO1,204,203,200_.jpg"
            },
            new Book
            {
                Id= 5,
                Title = "Code Complete: A Practical Handbook of Software Construction",
                Author = "Steve Mcconnell",
                Price = 340,
                Stock = 1,
                ImageFilePath = "https://images-na.ssl-images-amazon.com/images/I/41nvEPEagML._SX408_BO1,204,203,200_.jpg"
            }
        };
        #endregion


        async Task<IEnumerable<Book>> IBookRepository.GetAll()
        {
            return await Task.Run(() => _books);
        }

        async Task<Book> IBookRepository.GetBook(int id)
        {
            return await Task.Run(() => _books.FirstOrDefault(x => x.Id == id)!);
        }

        async Task<Book> IBookRepository.Add(Book book)
        {
            var newId = _books.Last().Id + 1;
            book.Id = newId;
            book.ImageFilePath = "/img/DefaultBookCover.png";

            await Task.Run(() =>
            {
                _books.Add(book);
            });

            return book;
        }
    }
}
