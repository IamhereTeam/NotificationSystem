using NS.Core.Entities;
using NS.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace NS.Data
{
    public class NSDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public NSDbContext(DbContextOptions<NSDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new UserConfiguration());

            builder
                .ApplyConfiguration(new DepartmentConfiguration());

            builder
                .ApplyConfiguration(new UserSettingsConfiguration());

            builder
                .ApplyConfiguration(new NotificationConfiguration());

            builder
                .ApplyConfiguration(new UserNotificationConfiguration());

            builder.Seed();
        }
    }
}
