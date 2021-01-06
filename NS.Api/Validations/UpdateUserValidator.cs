using FluentValidation;
using NS.DTO.Acount;

namespace NS.Api.Validations
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(a => a.Username)
                .MaximumLength(50);

            RuleFor(a => a.Password)
              .MaximumLength(50);
        }
    }
}
