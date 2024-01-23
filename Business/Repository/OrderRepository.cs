using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public OrderRepository(AppDbContext appDbContext, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IEnumerable<OrderStatisticsDTO> GetAllOrderStatistics()
        {
            //Get all orders and group them if the year, month, day and hour is the same.
            //Takes all Distinct orderIds and count them.
            var orders = _appDbContext.OrderProducts
            .Include(op => op.Order)
            .GroupBy(op => new
            {
                Year = op.Order.OrderDate.Year,
                Month = op.Order.OrderDate.Month,
                Day = op.Order.OrderDate.Day,
                Hour = op.Order.OrderDate.Hour
            })
           .Select(group => new OrderStatisticsDTO
           {
               Quantity = group.Select(op => op.OrderId).Distinct().Count(),
               DateTime = new DateTime(group.Key.Year, group.Key.Month, group.Key.Day, group.Key.Hour, 0, 0)
           })
            .ToList();

            return orders;
        }
        public IEnumerable<OrderStatisticsDTO> GetAllOrderStatisticsForDate()
        {
            var orders = _appDbContext.Orders
    .GroupBy(x => new
    {
        Year = x.OrderDate.Year,
        Month = x.OrderDate.Month,
        Day = x.OrderDate.Day
    })
    .Select(group => new OrderStatisticsDTO
    {
        DateTime = new DateTime(group.Key.Year, group.Key.Month, group.Key.Day),
        Quantity = group.Count()
    })
    .ToList();


            return orders;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _appDbContext.OrderProducts
              .Include(op => op.Product)
              .Include(op => op.Order)
              .Select(op => new OrderDTO
              {
                  OrderProduct = op,
                  Order = op.Order,
                  Product = op.Product,
                  Customer = _userManager.Users
                  .Where(x => x.Id == op.Order.CustomerId)
                  .Select(user => _mapper.Map<CustomerDTO>(user))
                  .FirstOrDefault()
              })
              .ToList();

            return orders;
        }

        public IEnumerable<OrderDTO> GetAllById(int id)
        {
            var orders = GetAll().Where(x => x.OrderProduct.OrderId == id).ToList();

            return orders;
        }
        public OrderDTO GetOrderByOrderId(int orderId)
        {
            var order = _appDbContext.OrderProducts
            .Where(o => o.OrderId == orderId)
            .Include(op => op.Product)
            .Include(op => op.Order)
            .Select(op => new OrderDTO
            {
                Order = op.Order,
                Product = op.Product

            })
            .FirstOrDefault();

            return order;
        }
        public Order Update(Order orderDTO)
        {
            var order = _appDbContext.Orders.FirstOrDefault(x => x.Id == orderDTO.Id);

            order.IsConfirmed = orderDTO.IsConfirmed;
            _appDbContext.SaveChanges();

            return orderDTO;
        }
        public Order ConfirmOrder(Order order)
        {
            var orderToUpdate = _appDbContext.Orders.FirstOrDefault(x => x.Id == order.Id);

            orderToUpdate.IsConfirmed = order.IsConfirmed;
            _appDbContext.SaveChanges();

            OrderHistory orderHistory = new OrderHistory() { Order = orderToUpdate };
            _appDbContext.OrderHistories.Add(orderHistory);
            _appDbContext.SaveChanges();


            return orderToUpdate;
        }
        public Order UpdateIsTakeAway(Order order)
        {
            var orderToUpdate = _appDbContext.Orders.FirstOrDefault(x => x.Id == order.Id);

            orderToUpdate.IsTakeAway = order.IsTakeAway;
            _appDbContext.SaveChanges();
            return orderToUpdate;
        }
        public Order UpdateIsReady(Order order)
        {
            var orderToUpdate = _appDbContext.Orders.FirstOrDefault(x => x.Id == order.Id);

            orderToUpdate.IsReady = order.IsReady;
            _appDbContext.SaveChanges();
            return orderToUpdate;
        }
        public string UpdateOrderMessage(int orderId, string message)
        {
            var order = _appDbContext.Orders.FirstOrDefault(x => x.Id == orderId);

            order.OrderMessage = message;
            _appDbContext.SaveChanges();

            return message;
        }
        public int Delete(int orderId)
        {
            var orderToDelete = _appDbContext.Orders
                                        .SingleOrDefault(o => o.Id == orderId);

            var orderProductsToDelete = _appDbContext.OrderProducts
                                            .Where(o => o.OrderId == orderId)
                                            .ToList();

            _appDbContext.OrderProducts.RemoveRange(orderProductsToDelete);


            _appDbContext.Orders.Remove(orderToDelete);


            _appDbContext.SaveChanges();

            return orderId;
        }
        public Order UpdateOrderMessage(Order order)
        {
            var orderToUpdate = _appDbContext.Orders.FirstOrDefault(o => o.Id == order.Id);

            orderToUpdate.OrderMessage = order.OrderMessage;
            _appDbContext.SaveChanges();

            return orderToUpdate;
        }

        public OrderProduct AddProductToOrder(OrderProduct orderProduct)
        {
            if (orderProduct == null)
            {
                throw new ArgumentNullException(nameof(orderProduct));
            }

            OrderProduct product = new OrderProduct() { OrderId = orderProduct.OrderId, ProductId = orderProduct.ProductId, Quantity = orderProduct.Quantity };

            //For some reason this crap works but not if you add orderProduct directly.
            _appDbContext.OrderProducts.Add(product);
            _appDbContext.SaveChanges();

            return orderProduct;
        }
        public OrderProduct DeleteProductFromOrder(OrderProduct orderProduct)
        {
            if (orderProduct == null)
                throw new ArgumentNullException(nameof(orderProduct));

            var order = _appDbContext.OrderProducts.FirstOrDefault(x => x.OrderId == orderProduct.OrderId && x.ProductId == orderProduct.ProductId);

            if (order != null)
            {
                _appDbContext.OrderProducts.Remove(order);
                _appDbContext.SaveChanges();
                return order;
            }

            return new OrderProduct();
        }

        public List<OrderProduct> UpdateOrderProducts(List<OrderProduct> orderProducts)
        {

            var orderId = orderProducts.FirstOrDefault()?.OrderId;

            foreach (var order in orderProducts)
            {
                var existingOrder = _appDbContext.OrderProducts.FirstOrDefault(x => x.OrderId == order.OrderId && x.ProductId == order.ProductId);

                if (existingOrder != null)
                {
                    existingOrder.Quantity = order.Quantity;
                }
                else if (existingOrder == null)
                {
                    _appDbContext.OrderProducts.Add(order);
                }
            }

            RemoveExistingOrders(orderProducts);

            _appDbContext.SaveChanges();
            return orderProducts;
        }
        public Order DeleteOrder(Order order)
        {
            var orderToDelete = _appDbContext.Orders.FirstOrDefault(x => x.Id == order.Id);

            orderToDelete.IsDeleted = true;

            _appDbContext.SaveChanges();

            return orderToDelete;
        }

        public void RemoveExistingOrders(List<OrderProduct> orderProducts)
        {
            if (orderProducts == null || orderProducts.Count == 0)
            {
                return;
            }

            var orderId = orderProducts.First().OrderId;

            // Get all existing OrderProducts for the specified OrderId
            var existingOrderProducts = _appDbContext.OrderProducts
                .Where(op => op.OrderId == orderId)
                .ToList();

            // Get the ProductIds of the OrderProducts to be removed
            var productIdsToRemove = existingOrderProducts
                .Where(op => !orderProducts.Any(updatedOp => updatedOp.ProductId == op.ProductId))
                .Select(op => op.ProductId)
                .ToList();

            // Remove OrderProducts based on OrderId and ProductIds
            _appDbContext.OrderProducts.RemoveRange(
                _appDbContext.OrderProducts
                    .Where(op => op.OrderId == orderId && productIdsToRemove.Contains(op.ProductId))
            );

            _appDbContext.SaveChanges();
        }

        public OrderDTO Create(CreateOrderDTO createOrderDTO)
        {
            if (createOrderDTO == null)
            {

                throw new ArgumentNullException(nameof(createOrderDTO));
            }


            var orderToCreate = _mapper.Map<CreateOrderDTO, Order>(createOrderDTO);

            var addedOrder = _appDbContext.Orders.Add(orderToCreate);
            _appDbContext.SaveChanges();


            if (createOrderDTO.OrderProducts != null && createOrderDTO.OrderProducts.Any())
            {
                foreach (var orderProduct in createOrderDTO.OrderProducts)
                {

                    var productToAdd = new OrderProduct
                    {
                        OrderId = addedOrder.Entity.Id,
                        ProductId = orderProduct.ProductId,
                        Quantity = orderProduct.Quantity
                    };

                    _appDbContext.OrderProducts.Add(productToAdd);
                }


                _appDbContext.SaveChanges();
            }

            return _mapper.Map<Order, OrderDTO>(addedOrder.Entity);
        }

        public int UpdateOrderProducts(int orderId, List<OrderProductDTO> orderProducts)
        {
            //Delete all rows from table OrderProducts for the current orderId.
            var orderProductsToDelete = _appDbContext.OrderProducts
                                            .Where(o => o.OrderId == orderId)
                                            .ToList();

            _appDbContext.OrderProducts.RemoveRange(orderProductsToDelete);
            _appDbContext.SaveChanges();

            //Add the new list of Products to the Orderproduct table.

            if (orderProducts != null)
            {
                foreach (var orderProduct in orderProducts)
                {

                    var productToAdd = new OrderProduct
                    {
                        OrderId = orderId,
                        ProductId = orderProduct.ProductId,
                        Quantity = orderProduct.Quantity
                    };

                    _appDbContext.OrderProducts.Add(productToAdd);
                }

                _appDbContext.SaveChanges();
            }
            return orderId;

        }

        public int AddProduct(OrderProductDTO orderProduct)
        {
            if (orderProduct.OrderId is not null)
            {
                var productToAdd = new OrderProduct
                {
                    OrderId = (int)orderProduct.OrderId,
                    ProductId = orderProduct.ProductId,
                    Quantity = orderProduct.Quantity
                };
                _appDbContext.OrderProducts.Add(productToAdd);
                _appDbContext.SaveChanges();

            }

            return orderProduct.ProductId;
        }



    }
}
