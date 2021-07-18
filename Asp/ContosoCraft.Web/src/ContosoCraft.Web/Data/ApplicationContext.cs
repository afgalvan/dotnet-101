using ContosoCraft.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoCraft.Web.Data
{
    public class ApplicationContext : DbContext
    {
        private DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
