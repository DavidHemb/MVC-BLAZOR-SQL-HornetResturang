namespace Hornet_Models.ModelsDTO
{
    public class CreateOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate = DateTime.Now;
        public bool IsConfirmed = false;
        public bool IsTakeAway { get; set; }
        public bool IsReady = false;
        public bool IsDeleted = false;

        public string? OrderMessage { get; set; }
        public string CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }

        public List<OrderProductDTO> OrderProducts { get; set; }


    }
}
