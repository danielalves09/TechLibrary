using TechLibrary.Api.Infraestructure.DataAcess;
using TechLibrary.Api.Infraestructure.Security.Cryptography;
using TechLibrary.Api.Infraestructure.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {

            var dbContext = new TechLibraryDbContext();

            var entity = dbContext.Users.FirstOrDefault(Users => Users.Email.Equals(request.Email));

            if (entity is null)
            {
                throw new InvalidLoginException();
            }

            var cryptograph = new BcryptAlgorithm();
            var passwordIsValid = cryptograph.VerifyPassword(request.Password, entity);

            if(passwordIsValid == false)
                throw new InvalidLoginException();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AcessToken = tokenGenerator.Generate(entity)
            };
        }
    }
}
