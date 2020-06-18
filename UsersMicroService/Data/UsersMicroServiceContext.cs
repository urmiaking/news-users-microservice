using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersMicroService.Models;

namespace UsersMicroService.Data
{
    public class UsersMicroServiceContext : DbContext
    {
        public UsersMicroServiceContext (DbContextOptions<UsersMicroServiceContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
