using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Product> GetAll()
        {
            return _appDbContext.Products;
        }
        public Product GetByProductId(int productId)
        {
            var Products = _appDbContext.Products
                .Where(p => p.Id == productId)
                .FirstOrDefault();

            return Products;
        }
        public Product GetByProductName(string productName)
        {
            var product = _appDbContext.Products
                .Where(p => p.Name == productName)
                .FirstOrDefault();

            return product;
        }
        public Product Create(Product obj)
        {
            var addedObj = _appDbContext.Products.Add(obj);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }
        public Product Update(Product obj)
        {
            var addedObj = _appDbContext.Products.Update(obj);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }
        public Product Delete(Product obj)
        {
            if (obj.IsDeleted)
            {
                obj.IsDeleted = false;
            }
            else
            {
                obj.IsDeleted = true;
            }
            var addedObj = _appDbContext.Products.Update(obj);
            _appDbContext.SaveChanges();

            return addedObj.Entity;
        }
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var orderProducts = _appDbContext.ProductCategories
                .Where(p => p.CategoryId == categoryId)
                .Select(pc => pc.Product)
                .ToList();

            return orderProducts;

        }

        public IEnumerable<OrderProduct> GetProductsByOrderId(int orderId)
        {
            var orderProducts = _appDbContext.OrderProducts
                .Where(p => p.OrderId == orderId)
                .ToList();

            return orderProducts;

        }

        public IEnumerable<ProductWithQuantityDTO> GetMostSoldProducts()
        {
            var productsWithQuantities = _appDbContext.OrderProducts
                    .GroupBy(op => op.Product)
                    .Select(group => new ProductWithQuantityDTO
                    {
                        Product = group.Key,
                        Quantity = group.Sum(op => op.Quantity),
                    })
                    .OrderByDescending(p => p.Quantity)
                    .ToList();

            return productsWithQuantities;
        }
        public IEnumerable<ProductWithQuantityDTO> GetMostSoldProductsDate(DateTime Start, DateTime End)
        {
            var productsWithQuantities = _appDbContext.OrderProducts
                    .Include(a => a.Order)
                    .Where(obj => obj.Order.OrderDate >= Start && obj.Order.OrderDate <= End)
                    .GroupBy(op => op.Product)
                    .Select(group => new ProductWithQuantityDTO
                    {
                        Product = group.Key,
                        Quantity = group.Sum(op => op.Quantity),
                    })
                    .OrderByDescending(p => p.Quantity)
                    .ToList();
            return productsWithQuantities;
        }

    }
}
