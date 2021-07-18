using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCraft.Web.Data;
using ContosoCraft.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoCraft.Web.Repositories
{
    public class MySqlProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public MySqlProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Save(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts() =>
            await _context.Products.ToListAsync();
    }
}
