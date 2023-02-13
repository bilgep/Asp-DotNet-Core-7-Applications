using Grpc.Core;
using TopBooks7_gRPC.Data;

namespace TopBooks7_gRPC.Services
{
    public class BookService : Books.BooksBase
    {
        private readonly IBookRepository repo;

        public BookService(IBookRepository repo)
        {
            this.repo = repo;
        }

        public override async Task<AllBooksResponse> GetAll(AllBooksRequest request, ServerCallContext context)
        {
            
            var response = new AllBooksResponse();
            response.Books.Add(await repo.GetAll());
            return response;
        }

        public override async Task<CreateNewBookResponse> CreateNew(CreateNewBookRequest request, ServerCallContext context)
        {

            return new CreateNewBookResponse(new CreateNewBookResponse
            {
                Book = await repo.Add(request.Book)
            });
        }

    }
}
