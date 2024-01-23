using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
    public class Employee : IdentityUser
    {
        public string Department { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime TerminatedDate { get; set; }
        public bool IsEmployed { get; set; }
    }
}
