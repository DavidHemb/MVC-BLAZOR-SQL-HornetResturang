using DataAccess.Models;

namespace Hornet_Models.ModelsDTO
{
    public class OrderDTO
    {
        public OrderProduct? OrderProduct { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public CustomerDTO? Customer { get; set; }
        //public string EmployeeRole { get; set; } // Change to string or IEnumerable<string>
        //public string CustomerRole { get; set; } // Change to string or IEnumerable<string>
    }
}
