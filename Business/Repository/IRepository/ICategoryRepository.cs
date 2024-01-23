using System;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;

namespace Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
        public IEnumerable<Category> GetAllWithProducts();
        public IEnumerable<ProductCategory> GetAllWithProductsFull();
        public Category GetByCategoryId(int categoryId);
        public Category Create(Category objProduct);
        public Category Update(Category objProduct);
        public Category Delete(Category objProduct);
    }
}