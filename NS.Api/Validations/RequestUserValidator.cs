using FluentValidation;
using NS.DTO.Acount;

namespace NS.Api.Validations
{
    public class RequestUserValidator : AbstractValidator<RequestUserModel>
    {
        public RequestUserValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50);

            RuleFor(a => a.Password)
              .NotEmpty().WithMessage("Password is required.")
              .MaximumLength(50);

            RuleFor(m => m.DepartmentId)
                .NotEmpty()
                .WithMessage("'Department Id' must not be 0.");
        }
    }
}
