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

            Validate(request);

            var cryptography = new BcryptAlgorithm();
            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = cryptography.HashPassword(request.Password)
            };

            var dbContext = new TechLibraryDbContext();
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson 
            {
                Name = entity.Name,
            };
        }

        private void Validate(RequestUserJson request)
        {
            var validator = new RegisteruserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
