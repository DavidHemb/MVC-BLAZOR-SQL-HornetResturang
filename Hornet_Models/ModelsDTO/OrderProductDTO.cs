namespace Hornet_Models.ModelsDTO
{
    public class OrderProductDTO
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? VatRate { get; set; }
    }
}
