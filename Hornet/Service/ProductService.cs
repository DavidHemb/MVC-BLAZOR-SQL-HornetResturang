using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Hornet.Service
{
    public class ProductService
    {
        // Dont forget to inject this in your page
        // @inject Hornet.Service.ProductService ProductService

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ProductService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        //PROPS
        private int _productId;
        public int GetProductId()
        {
            return _productId;
        }
        public void SetProductId(int productId)
        {
            _productId = productId;
        }
        //METHODS
        public async Task<IEnumerable<Product>> GetAll()
        {
            var apiBaseUrl = $"{_navigationManager.BaseUri}api/product";
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }
            return new List<Product>() { new Product { Name = "asd", Alcohol = 0, Id = 1, Price = 2 } };
        }
        public async Task<List<int>> CountAll()
        {
            var apiBaseUrl = $"{_navigationManager.BaseUri}api/product";
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<int>>(content);
                return products;
            }
            return null;
        }
        public async Task<Product> GetByProductId(int productId)
        {
            var apiBaseUrl = $"{_navigationManager.BaseUri}api/product";
            var response = await _httpClient.GetAsync(@$"https://localhost:7000/api/Product/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    Product product = JsonConvert.DeserializeObject<Product>(content);
                    return product;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return new Product { Name = "LOOSER" };
        }
        public async Task<Product> GetByProductName(string productName)
        {
            var response = await _httpClient.GetAsync(@$"https://localhost:7000/api/Product/GetByName?productName={productName}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    Product product = JsonConvert.DeserializeObject<Product>(content);
                    return product;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return new Product { Name = "Funkar inte" };
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {

            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Product");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }
            return null;
        }

        public async Task<IEnumerable<OrderProduct>> GetProductsByOrderId(int orderId)
        {

            var response = await _httpClient.GetAsync(@$"https://localhost:7000/api/Product/GetProductsByOrderId/{orderId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<OrderProduct>>(content);
                return products;
            }
            return null;
        }
        public async Task<bool> Create(Product obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/Product/Create", obj);
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
        public async Task<bool> Update(Product obj)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7000/api/Product/Update", obj);

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
        public async Task<bool> Delete(int productid)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7000/api/Product/Delete/{productid}");

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ProductWithQuantityDTO>> GetMostSoldProducts()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Product/GetMostSoldProducts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductWithQuantityDTO>>(content);
                return products;
            }
            return new List<ProductWithQuantityDTO>();
        }
        public async Task<IEnumerable<ProductWithQuantityDTO>> GetMostSoldProductsDate()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Product/GetMostSoldProductsDate");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductWithQuantityDTO>>(content);
                return products;
            }
            return new List<ProductWithQuantityDTO>();
        }
    }
}
