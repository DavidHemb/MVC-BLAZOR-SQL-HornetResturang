using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Categories;
        }
        public IEnumerable<Category> GetAllWithProducts()
        {
            return _appDbContext.ProductCategories
                .Include(c => c.Category)
                .Select(c => c.Category)
                .Distinct();
        }
        public IEnumerable<ProductCategory> GetAllWithProductsFull()
        {
            return _appDbContext.ProductCategories
                .Include(c => c.Category)
                .Include(a => a.Product)
                .Select(op => new ProductCategory
                {
                    CategoryId = op.CategoryId,
                    ProductId = op.ProductId,
                    Category = op.Category,
                    Product = op.Product,
                })
                .ToList();
        }
        public Category GetByCategoryId(int categoryId)
        {
            var category = _appDbContext.Categories
                .Where(p => p.Id == categoryId)
                .FirstOrDefault();

            return category;
        }
        public Category Create(Category obj)
        {
            var addedObj = _appDbContext.Categories.Add(obj);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }
        public Category Update(Category obj)
        {
            var addedObj = _appDbContext.Categories.Update(obj);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }
        public Category Delete(Category obj)
        {
            obj.IsDeleted = true;
            var addedObj = _appDbContext.Categories.Update(obj);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }


    }
}