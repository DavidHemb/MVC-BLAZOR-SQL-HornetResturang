using DataAccess.Models;
using Newtonsoft.Json;

namespace Hornet.Service
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;
        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetAllOrders()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Order");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }
            return new List<Product>() { new Product { Name = "asd", Alcohol = 0, Id = 1, Price = 2 } };
        }
    }
}
