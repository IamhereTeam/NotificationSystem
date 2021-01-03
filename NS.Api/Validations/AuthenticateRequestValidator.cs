using FluentValidation;
using NS.DTO.Acount;

namespace NS.Api.Validations
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.Password)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}