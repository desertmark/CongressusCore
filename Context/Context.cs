using CongressusCore.Areas.Posts.Models.Post;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CongressusCore.Contexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=test;User Id=SA;Password=nando.72;");
        }
    }
}