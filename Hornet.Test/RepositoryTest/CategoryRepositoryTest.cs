namespace Hornet.Test.RepositoryTest
{
    public class CategoryRepositoryTest : IDisposable
    {
        private ICategoryRepository _categoryRepository;
        private AppDbContext _appDbContext;

        public CategoryRepositoryTest()
        {
            var option = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _appDbContext = new AppDbContext(option);
            _appDbContext.Database.EnsureCreated();

            var mapper = A.Fake<IMapper>();
            _categoryRepository = new CategoryRepository(_appDbContext);
        }
        [Fact]
        public void CategoryRepository_GetAll_ReturnNotNull()
        {
            //Act
            var result = _categoryRepository.GetAll().ToList();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Category>>();
        }
        [Fact]
        public void CategoryRepository_GetAllWithProducts_ReturnNotNull()
        {
            //Act
            var result = _categoryRepository.GetAllWithProducts().ToList();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Category>>();
        }
        [Fact]
        public void CategoryRepository_GetByCategoryId_ReturnNotNull()
        {
            //Arrange
            var id = 1234567890;
            var category = new Category
            {
                Id = id,
                Name = "Test",
                Liquid = false,
                VatRate = 10,
                IsDeleted = false,

            };
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            //Act
            var result = _categoryRepository.GetByCategoryId(id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Category>();
        }
        [Fact]
        public void CategoryRepository_Create_ReturnsCreatedCategory()
        {
            //Arrange
            var category = new Category()
            {
                Id = 6543216,
                Name = "Test",
                Liquid = false,
                VatRate = 10,
                IsDeleted = false,
            };
            //Act
            var result = _categoryRepository.Create(category);
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBe(0);
            result.Name.Should().Be("Test");

            //Check that the category is saved to the db
            var retrievedCategory = _appDbContext.Categories.Find(category.Id);
            retrievedCategory.Should().NotBeNull();
            retrievedCategory.Should().BeEquivalentTo(category);
        }
        [Fact]
        public void CategoryRepository_Update_ReturnsUpdatedCategory()
        {
            var category = new Category()
            {
                Id = 123456789,
                Name = "Test",
                Liquid = false,
                VatRate = 10,
                IsDeleted = false,
            };
            //Add too database
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            //Modify with new values
            category.Name = "UpdateTest";
            //Act
            var result = _categoryRepository.Update(category);
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(123456789);
            result.Name.Should().Be("UpdateTest");
            //Check that the category is saved to the db
            var retrievedCategory = _appDbContext.Categories.Find(result.Id);
            retrievedCategory.Should().NotBeNull();
            retrievedCategory.Should().BeEquivalentTo(result);
        }
        [Fact]
        public void CategoryRepository_Delete_SetsIsDeletedAndReturnsDeletedCategory()
        {
            var category = new Category()
            {
                Id = 101111111,
                Name = "Test",
                Liquid = false,
                VatRate = 10,
                IsDeleted = false,
            };
            //Add too database
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            //Act
            var result = _categoryRepository.Delete(category);
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(101111111);
            result.Name.Should().Be("Test");
            result.IsDeleted.Should().BeTrue();
            //Check that the category is saved to the db
            var retrievedCategory = _appDbContext.Categories.Find(result.Id);
            retrievedCategory.Should().NotBeNull();
            retrievedCategory.IsDeleted.Should().BeTrue();
        }
        public void Dispose()
        {
            _appDbContext?.Dispose();
        }
    }
}
