using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContosoCraft.Api.Repositories;
using ContosoCraft.Models;

namespace ContosoCraft.Api.Services
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }

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

        public async Task<IEnumerable<Product>> GetAllProducts(
            CancellationToken cancellation) =>
            await _repository.GetAllProducts(cancellation);

        public async Task AddRating(string productId, double score,
            CancellationToken cancellation)
        {
            Product product = (await _repository.GetAllProducts(cancellation))
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new ProductNotFoundException(
                    $"Product with id {productId} was not found");
            }

            product.Ratings ??= new List<Rating>();
            var rating = new Rating {Score = score};
            product.AddRating(rating);

            await _repository.Update(product);
        }
    }
}
