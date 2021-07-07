using ContosoPets._1.Models;
using Microsoft.EntityFrameworkCore;
using Settings;

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
