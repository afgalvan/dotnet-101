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
    public class DetailsModel : PageModel
    {
        private readonly ContosoPets.Web.Data.ContosoPetsContext _context;

        public DetailsModel(ContosoPets.Web.Data.ContosoPetsContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
