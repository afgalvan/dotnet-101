using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCraft.Web.Models;

namespace ContosoCraft.Web.Repositories
{
    public interface IProductRepository
    {
        Task Save(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
