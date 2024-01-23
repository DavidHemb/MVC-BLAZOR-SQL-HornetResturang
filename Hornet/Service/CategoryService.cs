using DataAccess.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Hornet.Service
{
    public class CategoryService
    {
        // Dont forget to inject this in your page
        // @inject Hornet.Service.ProductService ProductService

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public CategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        //PROPS
        private int _categoryId;
        public int GetCategoryId()
        {
            return _categoryId;
        }
        public void SetCategoryId(int categoryId)
        {
            _categoryId = categoryId;
        }
        //METHODS
        public async Task<IEnumerable<Category>> GetAll()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Category");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<Category>>(content);
                return categories;
            }
            return null;
        }
        public async Task<IEnumerable<ProductCategory>> GetAllWithProductsFull()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Category/GetAllWithProductsFull");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ProductCategory>>(content);
                return categories;
            }
            return null;
        }
        public async Task<IEnumerable<Category>> GetAllWithProducts()
        {

            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Category/GetAllWithProducts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<Category>>(content);
                return categories;
            }
            return null;
        }
        public async Task<Category> GetByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync(@$"https://localhost:7000/api/Category/{categoryId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    Category category = JsonConvert.DeserializeObject<Category>(content);
                    return category;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return null;
        }

        public async Task<bool> Create(Category obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/Category/Create", obj);

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                else
                {

                    throw new Exception($"Failed to update category. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the caller
            }
        }
        public async Task<bool> Update(Category obj)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7000/api/Category/Update", obj);

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                else
                {

                    throw new Exception($"Failed to update category. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the caller
            }

        }
        public async Task<bool> Delete(int categoryId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7000/api/Category/Delete/{categoryId}");

            return response.IsSuccessStatusCode;
        }
    }
}