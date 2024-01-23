namespace DataAccess.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //Nested  properties
        public Order? Order { get; set; } = null!;
        public Product? Product { get; set; } = null!;
    }
}
