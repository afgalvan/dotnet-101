using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCraft.Models;

namespace ContosoCraft.Api.Repositories
{
    public interface IProductRepository
    {
        Task Save(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
