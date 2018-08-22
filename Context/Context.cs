using CongressusCore.Areas.Posts.Models;
using CongressusCore.Areas.Users.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CongressusCore.Contexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=test;User Id=SA;Password=nando.72;");
        }
    }
}