using Microsoft.EntityFrameworkCore;

namespace ContosoCraft.Web.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
