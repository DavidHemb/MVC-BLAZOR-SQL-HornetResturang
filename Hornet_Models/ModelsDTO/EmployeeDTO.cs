namespace Hornet_Models.ModelsDTO
{
    public class EmployeeDTO
    {
        //[JsonPropertyName("id")]
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        //[JsonPropertyName("department")]
        public string Department { get; set; }
        public bool IsEmployed { get; set; }
    }
}
