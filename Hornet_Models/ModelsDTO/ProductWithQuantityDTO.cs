using DataAccess.Models;

namespace Hornet_Models.ModelsDTO
{
    public class ProductWithQuantityDTO
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
