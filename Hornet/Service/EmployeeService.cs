using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net;

namespace Hornet.Service
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        private int _employeeId;
        public int GetEmployeeId()
        {
            return _employeeId;
        }
        public void SetEmployeeId(int employeeId)
        {
            _employeeId = employeeId;
        }
        public EmployeeService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            try
            {
                // API endpoint for getting all employees
                var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Employee/GetAllEmployee");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(content);
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }
        public async Task<bool> Create(Employee obj)
        {
            try
            {
                // API endpoint for creating a new employee
                var response = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/Employee/Create/", obj);


                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                else
                {

                    throw new Exception($"Failed to create Employee. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteEmployee(string employeeId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7000/api/Employee/Delete/{employeeId}");

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateEmployee(EmployeeDTO obj)
        {
            try
            {
                // API endpoint for updating an employee
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7000/api/Employee/Update/{obj.Id}", obj);

                
                response.EnsureSuccessStatusCode();
                return true;

            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("Användaren kunde inte hittas / uppdateras");
                return false;
            }
            catch (Exception ex)
            {
                // Log potential errors
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        public async Task<Employee> GetById(string employeeId)
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Employee/GetById/{employeeId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Employee>(content);
                return result;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}

