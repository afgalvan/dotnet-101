using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCraft.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ContosoCraft.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _service.GetAllProducts();
        }
    }
}
