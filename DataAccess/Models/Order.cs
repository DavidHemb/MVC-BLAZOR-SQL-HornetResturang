using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsTakeAway { get; set; }
        public bool IsReady { get; set; }
        public bool IsDeleted { get; set; }

        public string CustomerId { get; set; }

        [StringLength(250)]
        public string? OrderMessage { get; set; }
        public Customer? Customer { get; set; }
    }
}
