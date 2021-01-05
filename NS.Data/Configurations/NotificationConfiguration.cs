using NS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NS.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                  .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Subject)
                .HasMaxLength(200);

            builder
                .HasOne(m => m.User)
                .WithMany(a => a.Notifications)
                .HasForeignKey(m => m.UserId);

            builder
                .ToTable("Notifications");
        }
    }
}