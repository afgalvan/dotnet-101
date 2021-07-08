using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPets.Web.Models;

namespace ContosoPets.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ContosoPets.Web.Data.ContosoPetsContext _context;

        public IndexModel(ContosoPets.Web.Data.ContosoPetsContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
