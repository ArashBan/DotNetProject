using DotNetProject.Application.Contexts;
using DotNetProject.Domain.Entities;
using DotNetProject.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.Persistence.Contexts
{
    public class DatabaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
