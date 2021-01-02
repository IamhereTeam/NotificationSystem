using Microsoft.EntityFrameworkCore;
using NS.Core.Models;
using NS.Data.Configurations;

namespace NS.Data
{
    public class NSDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        public NSDbContext(DbContextOptions<NSDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new UserConfiguration());

            builder
                .ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
