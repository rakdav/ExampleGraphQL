using ExampleGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
