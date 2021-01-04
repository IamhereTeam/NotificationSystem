using NS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NS.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                  .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Department)
                .WithMany(a => a.Users)
                .HasForeignKey(m => m.DepartmentId);

            builder
                .HasOne(m => m.UserSettings)
                .WithOne(a => a.User)
                .HasForeignKey<UserSettings>(m => m.Id);

            builder
                .ToTable("Users");
        }
    }
}