using DataAccess.Models;

namespace Hornet_Models.ModelsDTO
{
    public class CategoryProductDTO
    {
        public ProductCategory? ProductCategory { get; set; }
        public Product? Product { get; set; }
        public Category? Category { get; set; }
        public Order? Order { get; set; }
        public OrderProduct? OrderProduct { get; set; }
    }
}
