using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
    public class Customer : IdentityUser
    {
        public string ShippingAdress { get; set; }
    }
}
