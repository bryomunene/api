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
    public class ProductCategoryController : ControllerBase
    {
        private ILogger _logger;
        private IProductCategoryService _service;

        private DatabaseContext _context;
        private MySqlConnection MySqlDatabase { get; set; }

        public ProductCategoryController(ILogger<ProductCategoryController> logger, IProductCategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/ProductCategory/index")]
        public ActionResult<List<ProductCategory>> Index()
        {
            return _service.GetProductCategories();
        }


        [HttpPost("/ProductCategory/add")]
        public ActionResult<ProductCategory> AddProductCategory(ProductCategory ProductCategory)
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
