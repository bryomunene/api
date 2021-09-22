using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;
using web_api.Services;

namespace web_api.Services
{
    public class ProductsCategoryService : IProductCategoryService
    {
        public DatabaseContext _databaseContext;

        public ProductsCategoryService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _databaseContext.productcategory.ToList();
        }        public ProductCategory AddProductCategory(ProductCategory productCategory)
        {
            _databaseContext.productcategory.Add(productCategory);
            _databaseContext.SaveChanges();
            return productCategory;
        }

        void IProductCategoryService.DeleteProductCategory(int Id)
        {
            var employee = _databaseContext.productcategory.FirstOrDefault(x => x.CategoryId == Id);
            if (employee != null)
            {
                _databaseContext.Remove(employee);
                _databaseContext.SaveChanges();
            }
        }

        void IProductCategoryService.UpdateProductCategory(ProductCategory productCategory)
        {
            _databaseContext.productcategory.Update(productCategory);
            _databaseContext.SaveChanges();
        }

        public ProductCategory GetProductCategory(int Id)
        {
            return _databaseContext.productcategory.FirstOrDefault(x => x.CategoryId == Id);
        }
    }
}
