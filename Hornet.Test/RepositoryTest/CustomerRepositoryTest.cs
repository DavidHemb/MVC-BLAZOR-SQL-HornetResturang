namespace Hornet.Test.RepositoryTest
{
    public class CustomerRepositoryTest
    {
        private ICustomerRepository _customerRepository;
        private AppDbContext _appDbContext;
        private IMapper _mapper;

        public CustomerRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _appDbContext = new AppDbContext(options);
            _appDbContext.Database.EnsureCreated();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });

            _mapper = mapperConfig.CreateMapper();

            _customerRepository = new CustomerRepository(_appDbContext, _mapper);
        }
        //[Fact]
        //public void CustomerRepository_Create_ReturnsCreatedCustomer()
        //{
        //    //Arrange
        //    var customer = new Customer
        //    {
        //        Id = "TestLösen123!",
        //        Email = "Test@Mail.com",
        //        UserName = "Test",
        //        PhoneNumber = "1234567890"
        //        //ShippingAdress = "Testvägen 1",
        //    };
        //    //_mapper.Map<Customer>(customer).ShippingAdress = "Testvägen 1";
        //    //Act
        //    var result = _customerRepository.Create(_mapper.Map<CustomerDTO>(customer)); ;
        //    //Assert
        //    result.Should().NotBeNull();
        //    result.UserName.Should().Be("Test");
        //    result.Email.Should().Be("Test@Mail.com");
        //    result.PhoneNumber.Should().Be("1234567890");

        //    var retrievedCustomer = _appDbContext.Customers.Find(result.Id);
        //    retrievedCustomer.Should().NotBeNull();
        //    retrievedCustomer.Should().BeEquivalentTo(_customerRepository.Get(result.Id),
        //        options => options.ExcludingMissingMembers());
        //}
        [Fact]
        public void CustomerRepository_Delete_ReturnsDeletedCustomer()
        {
            //Arrange
            var customer = new Customer
            {
                Id = "TestId",
                Email = "test@mail.com",
                UserName = "Test",
                PhoneNumber = "1234567890",
                ShippingAdress = "TestAdress",
            };
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();

            //Act
            var result = _customerRepository.Delete("TestId");
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("TestId");
            result.Email.Should().Be("test@mail.com");
            result.UserName.Should().Be("Test");
            result.PhoneNumber.Should().Be("1234567890");

            // make sure the customer is deleted from the db
            var deletedUser = _appDbContext.Customers.FirstOrDefault(c => c.Id == "TestId");
            deletedUser.Should().BeNull();
        }
        [Fact]
        public void CustomerRepository_Get_ReturnsCustomerById()
        {
            //Arrange
            var customer = new Customer
            {
                Id = "TestId",
                Email = "test@mail.com",
                UserName = "TestUser",
                PhoneNumber = "1234567890",
                ShippingAdress = "TestAdress",
            };
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();
            //Act
            var result = _customerRepository.Get("TestId");
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("TestId");
            result.Email.Should().Be("test@mail.com");
            result.UserName.Should().Be("TestUser");
            result.PhoneNumber.Should().Be("1234567890");
        }
        [Fact]
        public void CustomerRepository_Get_ReturnsEmptyCustomerDTOForNonexistentId()
        {
            //Act
            var result = _customerRepository.Get("NonexistentId");
            //Assert 
            result.Should().NotBeNull();
            result.Id.Should().BeNull();
            result.Email.Should().BeNull();
            result.UserName.Should().BeNull();
            result.PhoneNumber.Should().BeNull();
        }
        [Fact]
        public void CustomerRepository_Update_ReturnsUpdatedCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                Id = "TestId1",
                Email = "test@mail.com",
                UserName = "TestUser",
                PhoneNumber = "1234567890",
                ShippingAdress = "TestAdress",
            };
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();

            var updatedCustomerDTO = new CustomerDTO
            {
                Id = "TestId1",
                Email = "test@mail.com",
                UserName = "UpdatedUser",
                PhoneNumber = "1234567890",
            };

            // Act
            //the method updates UserName
            var result = _customerRepository.Update(updatedCustomerDTO);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("TestId1");
            result.UserName.Should().Be("UpdatedUser");
            result.Email.Should().Be("test@mail.com");
            result.PhoneNumber.Should().Be("1234567890");

            // Make sure the customer is updated in the database
            var updatedCustomer = _appDbContext.Customers.FirstOrDefault(c => c.Id == "TestId1");
            updatedCustomer.Should().NotBeNull();
            updatedCustomer.Should().BeEquivalentTo(_mapper.Map<Customer>(result),
                options => options.ExcludingMissingMembers()
                                  .Excluding(c => c.ShippingAdress)
                                  .Excluding(c => c.SecurityStamp)
                                  .Excluding(c => c.ConcurrencyStamp));
        }
    }
}
