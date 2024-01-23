using System;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;

namespace Business.Repository.IRepository
{
	public interface IProductRepository
	{
        public IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetProductsByCategoryId(int CategoryId);
        public IEnumerable<OrderProduct> GetProductsByOrderId(int orderId);
        public Product GetByProductId(int productId);
        public Product GetByProductName(string productName);
       // public Product GetByOrderId(int productId);
        public Product Create(Product objProduct);
        public Product Update(Product objProduct);
        public Product Delete(Product objProduct);
        public IEnumerable<ProductWithQuantityDTO> GetMostSoldProducts();
        public IEnumerable<ProductWithQuantityDTO> GetMostSoldProductsDate(DateTime Start, DateTime End);
    }
}
