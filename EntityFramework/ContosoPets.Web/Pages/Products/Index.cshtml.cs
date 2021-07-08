using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPets.Web.Data;
using ContosoPets.Web.Models;

namespace ContosoPets.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ContosoPets.Web.Data.ContosoPetsContext _context;

        public IndexModel(ContosoPets.Web.Data.ContosoPetsContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
