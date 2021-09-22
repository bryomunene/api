using Catel.Data;
using Microsoft.AspNetCore.Http;
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
        private readonly IProductCategoryService _service;

        public ProductCategoryController(ILogger<ProductCategoryController> logger, IProductCategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("ProductCategory/index")]
        public ActionResult Index()
        {
            var prodCategory = _service.GetProductCategories().ToList();

            return PartialView("index", prodCategory);
        }


        [HttpPost]
        [Route("[action]")]
        [Route("/ProductCategory/add")]
        [ValidateAntiForgeryToken]
        public ActionResult<ProductCategory> AddProductCategory([FromForm] ProductCategory ProductCategory)
        {
            try
            {
                if (ProductCategory == null)
                {
                    return BadRequest();
                }

                // Add custom model validation error
                var prodCat = _service.GetProductCategory(ProductCategory.CategoryId);

                if (prodCat != null)
                {
                    ModelState.AddModelError("Category ID", "Product Category already in use");
                    return BadRequest(ModelState);
                }

                _service.AddProductCategory(ProductCategory);
                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

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

        [HttpGet]
        [Route("[action]")]
        [Route("/ProductCategory/details/{id}")]
        public IEnumerable<ProductCategory> GetProductCategory(int id)
        {
            var existingProductCategory = _service.GetProductCategory(id);
            if (existingProductCategory != null)
            {
                return (IEnumerable<ProductCategory>)_service.GetProductCategory(existingProductCategory.CategoryId);
            }
            return (IEnumerable<ProductCategory>)NotFound($"Employee Not Found with ID : {existingProductCategory.CategoryId}");
        }
    }
}
