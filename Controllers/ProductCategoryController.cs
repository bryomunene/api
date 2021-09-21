using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Controllers
{
    [ApiController]
    [Route("ProductCategory/{action}")]
    public class ProductCategoryController : ControllerBase
    {
        public IActionResult Index()
        {
            ProductCategory context = HttpContext.RequestServices.GetService(typeof(web_api.Models.ProductCategory)) as ProductCategory;
            
            return PartialViewResult(context.GetAllProductCategories());
        }

        private IActionResult PartialViewResult(List<ProductCategory> productCategories)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            return "Returning from TestController Get Method";
        }

        public string Get2()
        {
            return "Returning from TestController Get2 Bryo Method";
        }
    }
}
