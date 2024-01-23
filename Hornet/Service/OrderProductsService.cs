using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Newtonsoft.Json;
using System.Net;

namespace Hornet.Service
{
    public class OrderProductsService
    {
        private readonly HttpClient _httpClient;

        public OrderProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Order");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<OrderDTO>>(content);
                return products;
            }
            return new List<OrderDTO>();
        }
        public async Task<IEnumerable<OrderDTO>> GetAllById(int id)
        {
            var response = await _httpClient.GetAsync(@$"https://localhost:7000/api/Order/GetAllById?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<List<OrderDTO>>(content);
                return orders;
            }
            return new List<OrderDTO>();
        }
        public async Task<HttpResponseMessage> AddProductToExistingOrder(OrderProduct orderProduct)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/AddProductToExistingOrder", orderProduct);


                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }
        }
        public async Task<HttpResponseMessage> UpdateOrder(Order orderDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Order>("https://localhost:7000/api/Order/Update", orderDTO);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var updatedOrder = JsonConvert.DeserializeObject<Order>(content);
                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }
        }
        public async Task<HttpResponseMessage> ConfirmOrder(Order order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/ConfirmOrder", order);


                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }
        }
        public async Task<HttpResponseMessage> UpdateIsTakeAway(Order order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/UpdateIsTakeAway", order);


                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }
        }
        public async Task<HttpResponseMessage> UpdateIsReady(Order order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/UpdateIsReady", order);


                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }
        }
        public async Task<HttpResponseMessage> UpdateOrderProducts(List<OrderDTO> orders)
        {
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            foreach (var order in orders)
            {
                orderProducts.Add(order.OrderProduct);
            }
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/UpdateOrderProducts", orderProducts);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }
        }
        public async Task<HttpResponseMessage> UpdateOrderMessage(Order order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/UpdateOrderMessage", order);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    Console.WriteLine($"Unsuccessful Response: {response.StatusCode}");

                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"Unsuccessful Response: {response.StatusCode}")
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }

        }
        public async Task<HttpResponseMessage> DeleteOrder(Order order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/Order/DeleteOrder", order);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    Console.WriteLine($"Unsuccessful Response: {response.StatusCode}");

                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"Unsuccessful Response: {response.StatusCode}")
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"BadRequest Response Content: {ex.Message}");
                return null;
            }

        }
    }
}
