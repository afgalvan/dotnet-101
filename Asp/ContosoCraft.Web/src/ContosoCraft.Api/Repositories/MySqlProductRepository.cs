using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContosoCraft.Api.Data;
using ContosoCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoCraft.Api.Repositories
{
    public class MySqlProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public MySqlProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Save(Product product, CancellationToken cancellation)
        {
            await _context.Products.AddAsync(product, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellation) =>
            await _context.Products.Include(p => p.Ratings).ToListAsync(cancellation);

        public async Task Update(Product product, CancellationToken cancellation)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
