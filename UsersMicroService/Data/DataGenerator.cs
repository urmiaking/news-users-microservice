using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroService.Models;

namespace UsersMicroService.Data
{
    public static class DataGenerator
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    FullName = "مدیر سایت",
                    IsActive = true,
                    UserType = "admin",
                    Password = "db901737c41e490dec8bded913f112e5e7c720c3847558f0e5c65128bdb1b34c"
                });
            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = 2,
                    Email = "user@user.com",
                    FullName = "کاربر سایت",
                    IsActive = true,
                    UserType = "user",
                    Password = "db901737c41e490dec8bded913f112e5e7c720c3847558f0e5c65128bdb1b34c"
                });
        }
    }
}
