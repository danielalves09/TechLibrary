using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisteruserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisteruserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatorio.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O email é obrigatorio.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatoria.");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password).MinimumLength(6).WithMessage("A senha deve ter no minimo 6 caracteres.");
            });


        }

    }
}
