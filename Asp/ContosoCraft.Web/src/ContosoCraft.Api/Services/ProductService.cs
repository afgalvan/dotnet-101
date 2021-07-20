using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCraft.Api.Repositories;
using ContosoCraft.Models;

namespace ContosoCraft.Web.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Save(Product product)
        {
            await _repository.Save(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts() =>
            await _repository.GetAllProducts();
    }
}
