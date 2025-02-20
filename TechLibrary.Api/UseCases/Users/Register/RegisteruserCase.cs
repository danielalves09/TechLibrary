using FluentValidation.Results;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infraestructure;
using TechLibrary.Api.Infraestructure.DataAcess;
using TechLibrary.Api.Infraestructure.Security.Cryptography;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisteruserCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            var dbContext = new TechLibraryDbContext();

            Validate(request, dbContext);

            var cryptography = new BcryptAlgorithm();
            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = cryptography.HashPassword(request.Password)
            };

            
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson 
            {
                Name = entity.Name,
                AcessToken = "token"
            };
        }

        private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
        {
            var validator = new RegisteruserValidator();

            var result = validator.Validate(request);

            var existUserEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));

            if(existUserEmail)
                result.Errors.Add(new ValidationFailure("Email", "Email já registrado na plataforma "));
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
