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
    public class indexModel : PageModel
    {
        private readonly web_api.Models.DatabaseContext _context;

        public indexModel(web_api.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IList<web_api.Models.ProductCategory> ProductCategory { get;set; }

        public async Task OnGetAsync()
        {
            ProductCategory = await _context.productcategory.ToListAsync();
        }
    }
}
