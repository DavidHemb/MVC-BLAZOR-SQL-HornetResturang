using DataAccess.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Hornet.Service
{
    public class ProductCategoryService
    {
        // Dont forget to inject this in your page
        // @inject Hornet.Service.ProductCategoryService ProductCategoryService

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;


        public ProductCategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }


        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7000/api/ProductCategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }
            return null;
        }
        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7000/api/ProductCategory/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var prodcat = JsonConvert.DeserializeObject<List<ProductCategory>>(content);
                return prodcat;
            }
            return null;
        }
        public async Task<bool> Create(ProductCategory prodcat)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/ProductCategory/Create", prodcat);

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
