using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContosoCraft.Models;

namespace ContosoCraft.Api.Repositories
{
    public interface IProductRepository
    {
        Task Save(Product product, CancellationToken cancellation);
        Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellation);
        Task Update(Product product, CancellationToken cancellation);
    }
}
