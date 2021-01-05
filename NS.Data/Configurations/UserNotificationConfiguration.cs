using NS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NS.Data.Configurations
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder
                  .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Date)
                .HasDefaultValueSql("getdate()");

            builder
                .HasOne(m => m.User)
                .WithMany(a => a.UserNotifications)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Notification)
                .WithMany(a => a.UserNotifications)
                .HasForeignKey(m => m.NotificationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("UserNotifications");
        }
    }
}