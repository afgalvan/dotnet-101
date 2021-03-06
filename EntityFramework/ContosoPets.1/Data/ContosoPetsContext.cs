using ContosoPets._1.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPets._1.Data
{
    public class ContosoPetsContext : DbContext
    {
        public ContosoPetsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer>     Customers     { get; set; }
        public DbSet<Order>        Orders        { get; set; }
        public DbSet<Product>      Products      { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
    }
}
