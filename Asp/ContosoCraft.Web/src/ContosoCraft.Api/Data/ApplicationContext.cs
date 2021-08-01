using ContosoCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoCraft.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating>  Ratings  { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
