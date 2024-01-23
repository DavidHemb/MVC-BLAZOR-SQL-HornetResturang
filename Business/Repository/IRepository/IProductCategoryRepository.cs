using System;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;

namespace Business.Repository.IRepository
{
    public interface IProductCategoryRepository
    {
        public IEnumerable<Product> GetProductsByCategoryId(int CategoryId);
        public IEnumerable<ProductCategory> GetProductCategories();
        public ProductCategory Create(ProductCategory prodcat);

    }
}
