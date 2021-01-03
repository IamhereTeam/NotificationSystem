using FluentValidation;
using NS.DTO.Acount;

namespace NS.Api.Validations
{
    public class AddDepartmentValidator : AbstractValidator<DepartmentModel>
    {
        public AddDepartmentValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}