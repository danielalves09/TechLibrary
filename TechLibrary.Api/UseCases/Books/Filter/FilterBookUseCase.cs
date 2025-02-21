using TechLibrary.Api.Infraestructure.DataAcess;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.UseCases.Books.Filter
{
    public class FilterBookUseCase
    {
        private const int PAGE_SIZE = 10;

        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var books = dbContext
                .Books
                .OrderBy(book => book.Title).ThenBy(book => book.Author)
                .Skip((request.PageNumber - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();

            var totalCount = dbContext.Books.Count();

            return new ResponseBooksJson
            {
                Pagination = new ResponsePaginationJson()
                {
                    PageNumber = request.PageNumber,
                    TotalCount = totalCount
                },
                Books = books.Select(book => new ResponseBookJson()
                {
                    id = book.Id,
                    title = book.Title,
                    author = book.Author,
                }).ToList()

            };

        }


    }
}
