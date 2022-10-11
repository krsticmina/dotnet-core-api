using dotnet_core_api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_api.Data.DbContexts
{
    public class BlogDatabaseContext : DbContext
    {
        public BlogDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
