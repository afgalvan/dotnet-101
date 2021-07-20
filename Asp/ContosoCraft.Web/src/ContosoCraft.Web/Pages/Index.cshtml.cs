using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCraft.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shared.Models;

namespace ContosoCraft.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel>  _logger;
        private readonly JsonProductLoader    _productLoader;
        public           IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            IEnumerable<Product> products, JsonProductLoader productLoader)
        {
            _logger        = logger;
            _productLoader = productLoader;
            Products       = products;
        }

        public async Task OnGet()
        {
            Products = await _productLoader.GetProductList();
        }
    }
}
