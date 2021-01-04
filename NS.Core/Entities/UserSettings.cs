namespace NS.Core.Entities
{
    public class UserSettings
    {
        public UserSettings()
        {
            DisabledDepartments = System.Array.Empty<int>();
        }

        public int Id { get; set; }
        public User User { get; set; }

        public int[] DisabledDepartments { get; set; }
    }
}
