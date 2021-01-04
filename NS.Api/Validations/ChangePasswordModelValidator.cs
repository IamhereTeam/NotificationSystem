using FluentValidation;
using NS.DTO.Acount;

namespace NS.Api.Validations
{
    public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordModelValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().Length(4, 32).WithMessage("The old password cannot be empty and the length must comply with the rules");
            RuleFor(x => x.NewPassword).NotEmpty().Length(4, 32).WithMessage("The new password cannot be empty and the length must comply with the rules")
                .Must(NewNotEqualsOld).WithMessage("The new password cannot be the same as the old password");
            RuleFor(x => x.NewPasswordRe).NotEmpty().WithMessage("The repeated password cannot be empty")
                .Must(ReEqualsNew).WithMessage("The repeated password must be the same as the new password");
        }

        private bool NewNotEqualsOld(ChangePasswordModel model, string newPwd) => model.OldPassword != newPwd;
        private bool ReEqualsNew(ChangePasswordModel model, string newPwdRe) => model.NewPassword == newPwdRe;
    }
}
