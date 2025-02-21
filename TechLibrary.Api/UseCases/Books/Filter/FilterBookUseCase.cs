using TechLibrary.Api.Infraestructure.DataAcess;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.UseCases.Books.Filter
{
    public class FilterBookUseCase
    {

        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var books = dbContext.Books.ToList();

            return new ResponseBooksJson
            {
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
