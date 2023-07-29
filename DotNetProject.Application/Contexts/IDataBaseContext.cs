using DotNetProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.Application.Contexts
{
    public interface IDataBaseContext
    {
        public DbSet<Product> Products { get; set; }

        public int SaveChanges();
    }
}
