using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Newtonsoft.Json;
using System.Net;

namespace Hornet.Service
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetAll()
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
        public async Task<IEnumerable<OrderStatisticsDTO>> GetAllOrderStatistics()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Order/GetAllOrderStatistics");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<OrderStatisticsDTO>>(content);
                return products;
            }
            return new List<OrderStatisticsDTO>();
        }
        public async Task<IEnumerable<OrderStatisticsDTO>> GetAllOrderStatisticsForDate()
        {
            var response = await _httpClient.GetAsync(@"https://localhost:7000/api/Order/GetAllOrderStatisticsForDate");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<OrderStatisticsDTO>>(content);
                return products;
            }
            return new List<OrderStatisticsDTO>();
        }
        public async Task<OrderDTO> GetOrderByOrderId(int orderId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7000/api/Order/{orderId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderDTO>(content);
                return order;
            }
            return null;
        }
        public async Task<HttpResponseMessage> Create(CreateOrderDTO createOrderDTO, CartService cartService)
        {
            try
            {

                var createdOrderResponse = await _httpClient.PostAsJsonAsync<CreateOrderDTO>(@"https://localhost:7000/api/Order", createOrderDTO);

                if (!createdOrderResponse.IsSuccessStatusCode)
                {

                    return createdOrderResponse;
                }


                var createdOrder = await createdOrderResponse.Content.ReadFromJsonAsync<OrderDTO>();

                var products = createOrderDTO.OrderProducts;


                var addProductsResponse = await _httpClient.PostAsJsonAsync($@"https://localhost:7000/api/Order", products);

                if (!addProductsResponse.IsSuccessStatusCode)
                {
                    cartService.ClearCart();

                    return addProductsResponse;
                }


                return createdOrderResponse;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }
        public async Task<HttpResponseMessage> UpdateOrderMessage(int orderId, string message)
        {
            try
            {

                var UpdateOrderMessageResponse = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/Order/UpdateOrderMessage/{orderId}", message);

                if (!UpdateOrderMessageResponse.IsSuccessStatusCode)
                {

                    return UpdateOrderMessageResponse;
                }
                return UpdateOrderMessageResponse;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }

        public async Task<HttpResponseMessage> UpdateOrderProducts(int orderId, List<OrderProductDTO> orderProducts)
        {
            try
            {

                var UpdateOrderProductsResponse = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/Order/UpdateOrderProducts/{orderId}", orderProducts);

                if (!UpdateOrderProductsResponse.IsSuccessStatusCode)
                {

                    return UpdateOrderProductsResponse;
                }
                return UpdateOrderProductsResponse;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }
        public async Task<HttpResponseMessage> AddProduct(OrderProductDTO orderProduct)
        {
            try
            {

                var AddProductsResponse = await _httpClient.PostAsJsonAsync($"https://localhost:7000/api/Order/AddProduct", orderProduct);

                if (!AddProductsResponse.IsSuccessStatusCode)
                {

                    return AddProductsResponse;
                }
                return AddProductsResponse;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }
        public async Task<bool> Delete(int orderId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7000/api/Order/Delete/{orderId}");

            return response.IsSuccessStatusCode;
        }
    }
}
