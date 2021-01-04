namespace NS.Core.Entities
{
    public class DisabledDepartments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }

        public User User { get; set; }
        public Department Department { get; set; }
    }
}