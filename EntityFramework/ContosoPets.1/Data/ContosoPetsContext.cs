using ContosoPets._1.Models;
using ContosoPets._1.Settings;
using Microsoft.EntityFrameworkCore;

namespace ContosoPets._1.Data
{
    public class ContosoPetsContext : DbContext
    {
        public DbSet<Customer>     Customers     { get; set; }
        public DbSet<Order>        Orders        { get; set; }
        public DbSet<Product>      Products      { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
        }
    }
}
