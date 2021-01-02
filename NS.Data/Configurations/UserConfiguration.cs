using NS.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NS.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(m => m.Department)
                .WithMany(a => a.Users)
                .HasForeignKey(m => m.DepartmentId);

            builder
                .ToTable("Users");
        }
    }
}