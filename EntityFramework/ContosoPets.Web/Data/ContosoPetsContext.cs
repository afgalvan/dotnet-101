using ContosoPets.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPets.Web.Data
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
