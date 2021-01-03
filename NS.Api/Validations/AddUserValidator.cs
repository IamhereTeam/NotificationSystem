using FluentValidation;
using NS.DTO.Acount;

namespace NS.Api.Validations
{
    public class AddUserValidator : AbstractValidator<UserModel>
    {
        public AddUserValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.DepartmentId)
                .NotEmpty()
                .WithMessage("'Department Id' must not be 0.");
        }
    }
}
