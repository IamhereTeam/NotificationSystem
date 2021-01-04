namespace NS.DTO.Acount
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRe { get; set; }
    }
}