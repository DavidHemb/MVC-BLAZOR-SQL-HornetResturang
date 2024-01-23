namespace Hornet.Test.RepositoryTest
{
    public class AdminRepositoryTest : IDisposable
    {
        private IAdminRepository _adminRepository;
        private AppDbContext _appDbContext;
        public AdminRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _appDbContext = new AppDbContext(options);
            _appDbContext.Database.EnsureCreated();

            var userManager = new UserManager<IdentityUser>(
                new UserStore<IdentityUser>(_appDbContext),
                null, null, null, null, null, null, null, null);
            var mapper = A.Fake<IMapper>();
            _adminRepository = new AdminRepository(_appDbContext, userManager, mapper);
        }
        private async Task<AppDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Orders.CountAsync() == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Orders.Add(
                    new Order()
                    {
                        Id = 1234567890,
                        OrderDate = DateTime.Now,
                        IsConfirmed = true,
                        IsTakeAway = true,
                        IsReady = true,
                        IsDeleted = false,
                        CustomerId = Guid.NewGuid().ToString(),
                        OrderMessage = "Test"
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public void AdminRepository_GetAll_ReturnNotNull()
        {
            //Arrange                   
            //Act
            var result = _adminRepository.GetAllOrders();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<OrderDTO>>();

        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}


