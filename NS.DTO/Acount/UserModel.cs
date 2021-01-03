namespace NS.DTO.Acount
{
    public class RequestUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int DepartmentId { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }
    }
}