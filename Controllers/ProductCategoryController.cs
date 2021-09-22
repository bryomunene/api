using Catel.Data;
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
        private readonly IProductCategoryService _service;

        public ProductCategoryController(ILogger<ProductCategoryController> logger, IProductCategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/ProductCategory/index")]
        public IEnumerable<ProductCategory> Index()
        {
            return _service.GetProductCategories();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("/ProductCategory/add")]
        public ActionResult<ProductCategory> AddProductCategory([FromForm] ProductCategory ProductCategory)
        {
            _service.AddProductCategory(ProductCategory);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("/ProductCategory/update/{id}")]
        public ActionResult<ProductCategory> UpdateProductCategory(ProductCategory ProductCategory)
        {
            _service.UpdateProductCategory(ProductCategory);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("/ProductCategory/delete/{id}")]
        public ActionResult<string> DeleteProductCategory(int id)
        {
            var existingProductCategory= _service.GetProductCategory(id);
            if (existingProductCategory != null)
            {
                _service.DeleteProductCategory(existingProductCategory.CategoryId);
                return Ok();
            }
            return NotFound($"Employee Not Found with ID : {existingProductCategory.CategoryId}");
        }
    }
}
