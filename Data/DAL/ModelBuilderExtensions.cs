using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Utilities.Helpers;
using System;

namespace Data.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Cretion of User
            var admin = new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                PhoneNumber = "0555554545161",
                Role = "Admin",
                IsActive = true
            };
            admin.PasswordHash = HashHelper.CreatePasswordHash("Admin123", admin.SecretKey);
            modelBuilder.Entity<User>().HasData(admin);
            #endregion
        }
    }
}
