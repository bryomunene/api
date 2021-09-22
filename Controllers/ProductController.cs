using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_api.Services;
using web_api.Models;
using Microsoft.AspNetCore.Http;

namespace web_api.Controllers
{
    [ApiController]
    [Route("Product/{action}")]
    public class ProductController : Controller
    {
        private ILogger _logger;
        private readonly IProductService _service;

        public ProductController(ILogger<ProductCategoryController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("Product/index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("Product/add")]
        [Route("Product/add/{Id}")]
        public IActionResult AddProduct([FromForm] Product Product)
        {
            try
            {
                if (Product == null)
                {
                    return BadRequest();
                }

                // Add custom model validation error
                var prodCat = _service.GetProduct(Product.ProductId);

                if (prodCat != null)
                {
                    ModelState.AddModelError("Category ID", "Product Category already in use");
                    return BadRequest(ModelState);
                }

                _service.AddProduct(Product);

                TempData["custdetails"] = string.Format("Product Category : {0}", Product.ProductName, " successfully saved.");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
