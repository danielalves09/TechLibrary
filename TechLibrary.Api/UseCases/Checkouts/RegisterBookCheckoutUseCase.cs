﻿using TechLibrary.Api.Infraestructure.DataAcess;
using TechLibrary.Api.Services.LoggedUser;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Checkouts
{
    public class RegisterBookCheckoutUseCase
    {


        private const int MAX_DAYS = 7;

        private readonly LoggedUserService _loggedUser;
        public RegisterBookCheckoutUseCase(LoggedUserService loggedUser)
        {
            _loggedUser = loggedUser;
        }

        public void Execute(Guid bookId)
        {
            var dbContext = new TechLibraryDbContext();

            Validate(dbContext, bookId);


            var user = _loggedUser.User(dbContext);


            var entity = new Domain.Entities.Checkout
            {
                UserId = user.Id,
                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_DAYS),
                
            };

            dbContext.Checkouts.Add(entity);
            


            dbContext.SaveChanges();

        }
    


    private void Validate(TechLibraryDbContext dbContext, Guid bookId)
        {
            var book = dbContext.Books.FirstOrDefault(book => book.Id == bookId);

            if (book is null)
            {
                throw new NotFoundException("Livro Não Encontrado");
            }

            var amountNotReturned = dbContext
                .Checkouts
                .Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            if(amountNotReturned == book.Amount)
            {
                throw new ConflictException("Livro Indisponível para empréstimo.");
            }

        }
    }
}
