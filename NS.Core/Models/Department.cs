using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NS.Core.Models
{
    public class Department
    {
        public Department()
        {
            Users = new Collection<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}