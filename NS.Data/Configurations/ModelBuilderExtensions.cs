using NS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace NS.Data.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // admin
            byte[] passwordHash = new byte[] { 97, 127, 134, 9, 60, 192, 236, 120, 228, 127, 140, 151, 18, 101, 11, 46, 225, 9, 109, 124, 40, 88, 98, 221, 110, 199, 80, 12, 209, 52, 143, 102, 164, 224, 61, 172, 140, 86, 109, 116, 235, 165, 95, 111, 227, 173, 37, 120, 3, 231, 55, 102, 95, 193, 38, 81, 114, 135, 58, 109, 44, 162, 68, 42 };
            byte[] passwordSalt = new byte[] { 243, 202, 23, 184, 232, 158, 110, 116, 229, 20, 131, 107, 58, 134, 149, 185, 191, 250, 126, 159, 1, 205, 57, 215, 11, 103, 164, 36, 172, 99, 180, 47, 5, 101, 117, 84, 124, 209, 199, 88, 21, 204, 51, 42, 239, 242, 69, 66, 73, 20, 228, 252, 119, 192, 213, 244, 11, 162, 34, 17, 36, 178, 137, 60, 9, 239, 45, 22, 169, 25, 141, 55, 215, 41, 166, 122, 108, 129, 100, 95, 126, 160, 38, 230, 228, 163, 125, 12, 118, 179, 1, 10, 168, 108, 59, 162, 19, 57, 109, 115, 183, 210, 133, 68, 77, 161, 174, 104, 75, 240, 71, 166, 213, 213, 68, 18, 74, 110, 192, 51, 190, 134, 68, 247, 197, 130, 17, 159 };

            // Department
            modelBuilder.Entity<Department>()
                .HasData(
                   new Department { Id = 1, Name = "HR" },
                   new Department { Id = 2, Name = "Development" },
                   new Department { Id = 3, Name = "DevOps" },
                   new Department { Id = 4, Name = "Sales" },
                   new Department { Id = 5, Name = "Management" }
            );

            // Users
            modelBuilder.Entity<User>()
                .HasData(
                   new User { Id = 1,   FirstName = "Marilyn",  LastName = "Monroe",        Username = "marilyn",   DepartmentId = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 2,   FirstName = "Abraham",  LastName = "Lincoln",       Username = "abraham",   DepartmentId = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 3,   FirstName = "Nelson",   LastName = "Mandela",       Username = "nelson",    DepartmentId = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 4,   FirstName = "John",     LastName = "Kennedy",       Username = "john",      DepartmentId = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 5,   FirstName = "Martin",   LastName = "Luther King",   Username = "martin",    DepartmentId = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 6,   FirstName = "Queen",    LastName = "Elizabeth",     Username = "queen",     DepartmentId = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 7,   FirstName = "Winston",  LastName = "Churchill",     Username = "winston",   DepartmentId = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 8,   FirstName = "Donald",   LastName = "Trump",         Username = "donald",    DepartmentId = 3, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 9,   FirstName = "Muhammad", LastName = "Ali",           Username = "muhammad",  DepartmentId = 3, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 10,  FirstName = "Elon",     LastName = "Musk",          Username = "elon",      DepartmentId = 5, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 11,  FirstName = "Jeff",     LastName = "Bezos",         Username = "jeff",      DepartmentId = 5, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                   new User { Id = 12,  FirstName = "Bill",     LastName = "Gates",         Username = "bill",      DepartmentId = 5, PasswordHash = passwordHash, PasswordSalt = passwordSalt }
                   );
        }
    }
}