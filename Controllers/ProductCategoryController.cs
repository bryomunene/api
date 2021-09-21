using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;
using web_api.Services;

namespace web_api.Controllers
{
    [ApiController]
    [Route("ProductCategory/{action}")]
    public class ProductCategoryController : Controller
    {
        private ILogger _logger;
        private IProductCategoryService _service;
        private DatabaseContext _context;
        private MySqlConnection MySqlDatabase { get; set; }

        public ProductCategoryController(ILogger<ProductCategoryController> logger, IProductCategoryService service, DatabaseContext context)
        {
            _logger = logger;
            _service = service;
            _context = context;
        }

        [HttpGet("/ProductCategory/index")]
        public IActionResult Index()
        {
            ProductCategory context = HttpContext.RequestServices.GetService(typeof(web_api.Models.ProductCategory)) as ProductCategory;
            
            return View(_service.GetProductCategories());
        }

        //[HttpPost("/ProductCategory/index")]
        //private IActionResult PartialViewResult(List<ProductCategory> productCategories)
        //{
        //    throw new NotImplementedException();
        //}

        public string Get()
        {
            return "Returning from TestController Get Method";
        }

        public string Get2()
        {
            return "Returning from TestController Get2 Bryo Method";
        }

        [HttpPost("/ProductCategory/add")]
        public ActionResult<ProductCategory> AddProduct(ProductCategory ProductCategory)
        {
            _service.AddProductCategory(ProductCategory);
            return ProductCategory;
        }

        [HttpPut("/ProductCategory/{id}")]
        public ActionResult<ProductCategory> UpdateProductCategory(string id, ProductCategory ProductCategory)
        {
            _service.UpdateProductCategory(id, ProductCategory);
            return ProductCategory;
        }

        [HttpDelete("/ProductCategory/{id}")]
        public ActionResult<string> DeleteProductCategory(string id)
        {
            _service.DeleteProductCategory(id);
            //_logger.LogInformation("products", _products);
            return id;
        }
    }
}
