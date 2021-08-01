using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using ContosoCraft.Api.Services;
using ContosoCraft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCraft.Api.Controllers
{
    public class AddRateRequest
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public double Rate { get; set; }
    }

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
        public async Task<IEnumerable<Product>> GetProducts(
            CancellationToken cancellation)
        {
            return await _service.GetAllProducts(cancellation);
        }

        [HttpPatch("Rate")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddRating(
            [FromBody] AddRateRequest request, CancellationToken cancellation)
        {
            try
            {
                await _service.AddRating(request.Id, request.Rate, cancellation);
                return Ok("Rating added");
            }
            catch (ProductNotFoundException exception)
            {
                ModelState.AddModelError("ProductNotFound", exception.Message);
                return NotFound(ModelState);
            }
        }
    }
}
