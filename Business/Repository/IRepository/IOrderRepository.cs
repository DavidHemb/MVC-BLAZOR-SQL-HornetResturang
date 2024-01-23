using DataAccess.Migrations;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IOrderRepository
    {
        public IEnumerable<OrderDTO> GetAll();
        public OrderDTO GetOrderByOrderId(int orderId);
        public OrderDTO Create(CreateOrderDTO createOrderDTO);
        public string UpdateOrderMessage(int orderId, string orderMessage);
        public int UpdateOrderProducts(int orderId, List<OrderProductDTO> orderProducts);
        public int AddProduct(OrderProductDTO orderProduct);
        public int Delete(int orderId);
        public IEnumerable<OrderDTO> GetAllById(int id);
        public OrderProduct AddProductToOrder(OrderProduct orderProduct);
        public OrderProduct DeleteProductFromOrder(OrderProduct orderProduct);
        public List<OrderProduct> UpdateOrderProducts(List<OrderProduct> orderProduct);
        public Order UpdateOrderMessage(Order order);
        public Order DeleteOrder(Order order);
        public Order Update(Order orderDTO);
        public Order ConfirmOrder(Order order);
        public Order UpdateIsTakeAway(Order order);
        public Order UpdateIsReady(Order order);
        public IEnumerable<OrderStatisticsDTO> GetAllOrderStatistics();
        public IEnumerable<OrderStatisticsDTO> GetAllOrderStatisticsForDate();
    }
}
