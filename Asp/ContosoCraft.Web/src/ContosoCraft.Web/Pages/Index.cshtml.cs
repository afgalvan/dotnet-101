using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraft.Web.Models;
using ContosoCraft.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCraft.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonProductService  _jsonProductService;

        public IndexModel(ILogger<IndexModel> logger,
            JsonProductService jsonProductService)
        {
            _logger                 = logger;
            _jsonProductService = jsonProductService;
        }

        public async Task OnGet()
        {
            IEnumerable<Product> products = await _jsonProductService.GetProductList();

            string productsString = string.Join(",\n", products.Select(product => product.ToString()));
            _logger.Log(LogLevel.Information, productsString);
        }
    }
}
