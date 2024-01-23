using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;

namespace Business.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ProductCategory Create(ProductCategory prodcat)
        {
            var addedObj = _appDbContext.ProductCategories.Add(prodcat);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var Products = _appDbContext.ProductCategories
                .Where(p => p.CategoryId == categoryId)
                .Select(pc => pc.Product)
                .ToList();

            return Products;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return _appDbContext.ProductCategories;
        }



    }
}
