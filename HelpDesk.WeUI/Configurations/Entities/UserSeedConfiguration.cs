using HelpDesk.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.WebUI.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(
                 new AppUser
                 {
                     Id = "b1a6d8c4-9e7f-4d20-aae3-6f1b2c9d5e5a",
                     Email = "administrator@administrator.com",
                     NormalizedEmail = "ADMINISTRATOR@ADMINISTRATOR.COM",
                     NormalizedUserName = "ADMINISTRATOR@ADMINISTRATOR.COM",
                     UserName = "administrator@administrator.com",
                     Name = "Administrator",
                     PasswordHash = hasher.HashPassword(null, "Administrator@123"),
                     EmailConfirmed = true
                 },
                 new AppUser
                 {
                     Id = "f8c6a9d2-5e4f-4b10-9e1d-3c7b8a6f9d2c",
                     Email = "admin@admin.com",
                     NormalizedEmail = "ADMIN@ADMIN.COM",
                     NormalizedUserName = "ADMIN@ADMIN.COM",
                     UserName = "admin@admin.com",
                     Name = "Admin",
                     PasswordHash = hasher.HashPassword(null, "Admin@123"),
                     EmailConfirmed = true
                 },
                 new AppUser
                 {
                     Id = "d3e8c5b9-1a2b-4c3d-8e9f-5a6b7c8d9e0f",
                     Email = "user@user.com",
                     NormalizedEmail = "USER@USER.COM",
                     NormalizedUserName = "USER@USER.COM",
                     UserName = "user@user.com",
                     Name = "User",
                     PasswordHash = hasher.HashPassword(null, "User@123"),
                     EmailConfirmed = true
                 }
            );
            
            /*builder.HasData(
                 new AppUser
                 {
                     Id = "408aa945-3d84-4421-8342-7269ec64d949",
                     Email = "administrator@administrator.com",
                     NormalizedEmail = "ADMINISTRATOR@ADMINISTRATOR.COM",
                     NormalizedUserName = "ADMINISTRATOR@ADMINISTRATOR.COM",
                     UserName = "administrator@administrator.com",
                     Name = "Administrator",
                     PasswordHash = hasher.HashPassword(null, "Administrator@123"),
                     EmailConfirmed = true
                 },
                 new AppUser
                 {
                     Id = "3f4631bd-f907-4409-b416-ba356312e659",
                     Email = "admin@admin.com",
                     NormalizedEmail = "ADMIN@ADMIN.COM",
                     NormalizedUserName = "ADMIN@ADMIN.COM",
                     UserName = "admin@admin.com",
                     Name = "Admin",
                     PasswordHash = hasher.HashPassword(null, "Admin@123"),
                     EmailConfirmed = true
                 },
                 new AppUser
                 {
                     Id = "734988a4-ec6e-4ab2-b3d7-6566e29a0656",
                     Email = "user@user.com",
                     NormalizedEmail = "USER@USER.COM",
                     NormalizedUserName = "USER@USER.COM",
                     UserName = "user@user.com",
                     Name = "User",
                     PasswordHash = hasher.HashPassword(null, "User@123"),
                     EmailConfirmed = true
                 }
            );*/
        }
    }
}