using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Pages.ProductCategory
{
    public class deleteModel : PageModel
    {
        private readonly web_api.Models.DatabaseContext _context;

        public deleteModel(web_api.Models.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public web_api.Models.ProductCategory ProductCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory = await _context.productcategory.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (ProductCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory = await _context.productcategory.FindAsync(id);

            if (ProductCategory != null)
            {
                _context.productcategory.Remove(ProductCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
