using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ContosoCraft.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
