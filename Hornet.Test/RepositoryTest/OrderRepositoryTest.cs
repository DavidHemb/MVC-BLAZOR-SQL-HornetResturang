using FakeItEasy;

namespace Hornet.Test.RepositoryTest
{
    public class OrderRepositoryTest
    {
        private IOrderRepository _orderRepository;
        private AppDbContext _appDbContext;
        private UserManager<IdentityUser> _userManager;
        private IMapper _mapper;

        public OrderRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _appDbContext = new AppDbContext(options);
            _appDbContext.Database.EnsureCreated();

            _userManager = A.Fake<UserManager<IdentityUser>>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();
            });

            _mapper = mapperConfig.CreateMapper();

            _orderRepository = new OrderRepository(_appDbContext, _userManager, _mapper);
        }
        [Fact]
        public void OrderRepository_GetAllOrderStatistics_ReturnsOrderStatistics()
        {
            //Arrange
            var order1 = new Order
            {
                Id = 123,
                OrderDate = new DateTime(2023, 1, 1, 10, 0, 0),
                IsConfirmed = false,
                IsTakeAway = false,
                IsReady = false,
                IsDeleted = false,
                CustomerId = "1",
            };
            var order2 = new Order
            {
                Id = 231,
                OrderDate = new DateTime(2023, 1, 1, 11, 0, 0),
                IsConfirmed = false,
                IsTakeAway = false,
                IsReady = false,
                IsDeleted = false,
                CustomerId = "2",
            };

            _appDbContext.Orders.Add(order1);
            _appDbContext.Orders.Add(order2);
            _appDbContext.SaveChanges();

            var orderProduct1 = new OrderProduct
            {
                OrderId = 143,
                ProductId = 1,
                Quantity = 1,
            };
            var orderProduct2 = new OrderProduct
            {
                OrderId = 2,
                ProductId = 2,
                Quantity = 1,
            };
            
            _appDbContext.OrderProducts.Add(orderProduct1);
            _appDbContext.OrderProducts.Add(orderProduct2);
            _appDbContext.SaveChanges();         

            //Act
            var result = _orderRepository.GetAllOrderStatistics();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<OrderStatisticsDTO>>();
            result.Should().HaveCount(1);
        }
        [Fact]
        public void OrderRepository_GetAllOrderStatisticsForDate_ReturnsOrderStatisticsForDate()
        {
            //Arrange
            var order1 = new Order
            {
                Id = 1,
                OrderDate = new DateTime(2023, 1, 1, 10, 0, 0),
                IsConfirmed = false,
                IsTakeAway = false,
                IsReady = false,
                IsDeleted = false,
                CustomerId = "1",
            };
            var order2 = new Order
            {
                Id = 2,
                OrderDate = new DateTime(2023, 1, 1, 11, 0, 0),
                IsConfirmed = false,
                IsTakeAway = false,
                IsReady = false,
                IsDeleted = false,
                CustomerId = "2",
            };
            var order3 = new Order
            {
                Id = 3,
                OrderDate = new DateTime(2023, 1, 2, 10, 0, 0),
                IsConfirmed = false,
                IsTakeAway = false,
                IsReady = false,
                IsDeleted = false,
                CustomerId = "3",
            };
            _appDbContext.Orders.Add(order1);
            _appDbContext.Orders.Add(order2);
            _appDbContext.Orders.Add(order3);
            _appDbContext.SaveChanges();

            //Act
            var result = _orderRepository.GetAllOrderStatisticsForDate();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<OrderStatisticsDTO>>();
            result.Should().HaveCount(2);            
        }        
    }
}
