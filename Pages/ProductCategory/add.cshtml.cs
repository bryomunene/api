using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_api.Models;

namespace web_api.Pages.ProductCategory
{
    public class addModel : PageModel
    {
        private readonly web_api.Models.DatabaseContext _context;

        public addModel(web_api.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public web_api.Models.ProductCategory ProductCategory { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.productcategory.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("ProductCategory/index");
        }
    }
}
