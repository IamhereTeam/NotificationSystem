using System;
using System.Linq;
using NS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NS.Data.Configurations
{
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            var converter = new ValueConverter<int[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToArray());

            builder
                .Property(e => e.DisabledDepartments)
                .HasConversion(converter);

            builder
                .ToTable("UserSettings");
        }
    }
}