using DataAccess.Models;
using Hornet.Service;




namespace Hornet.Test.ControllerTest
{
    public class CartServiceTest
    {
        

        [Fact]
        public void AddToCart_ItemAddedCorrectly()
        {
            // Arrange
            var cartService = new CartService();

            var fakeProduct_1 = new Product
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 99,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            var fakeProduct_2 = new Product
            {
                Id = 2,
                Name = "Test2",
                Description = "Test2",
                Price = 89,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            // Act
            cartService.AddToCart(fakeProduct_1, 1);
            cartService.AddToCart(fakeProduct_2, 2);
            cartService.AddToCart(fakeProduct_1, 3);

            // Assert
            Assert.True(cartService.CartItems.ContainsKey(fakeProduct_2));
            Assert.Equal(4, cartService.CartItems[fakeProduct_1]);
        }
        [Fact]
        public void RemoveFromCart_ItemRemovedCorrectly()
        {
            // Arrange
            var cartService = new CartService();

            var fakeProduct_1 = new Product
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 99,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            var fakeProduct_2 = new Product
            {
                Id = 2,
                Name = "Test2",
                Description = "Test2",
                Price = 89,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            // Act
            cartService.AddToCart(fakeProduct_1, 1);
            cartService.AddToCart(fakeProduct_2, 2);
            cartService.AddToCart(fakeProduct_1, 3);
            cartService.RemoveFromCart(fakeProduct_1);

            // Assert
            Assert.False(cartService.CartItems.ContainsKey(fakeProduct_1));
            Assert.Equal(2, cartService.CartItems[fakeProduct_2]);
        }
        [Fact]
        public void ClearCart_ClearCartCorrectly()
        {
            // Arrange
            var cartService = new CartService();

            var fakeProduct_1 = new Product
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 99,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            var fakeProduct_2 = new Product
            {
                Id = 2,
                Name = "Test2",
                Description = "Test2",
                Price = 89,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            // Act
            cartService.AddToCart(fakeProduct_1, 1);
            cartService.AddToCart(fakeProduct_2, 2);
            cartService.AddToCart(fakeProduct_1, 3);
            cartService.ClearCart();

            // Assert
            Assert.False(cartService.CartItems.ContainsKey(fakeProduct_1));
            Assert.False(cartService.CartItems.ContainsKey(fakeProduct_2));

        }


        [Fact]
        public void GetTotalQuantity_ReturnCorrectQuantity()
        {
            // Arrange
            var cartService = new CartService();

            var fakeProduct_1 = new Product
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 99,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            var fakeProduct_2 = new Product
            {
                Id = 2,
                Name = "Test2",
                Description = "Test2",
                Price = 89,
                Alcohol = 0,
                Lactose = true,
                Gluten = true,
                Vegan = true,
                IsDeleted = false,
                ImagePath = null
            };

            // Act
            cartService.AddToCart(fakeProduct_1, 1);
            cartService.AddToCart(fakeProduct_2, 2);
            cartService.AddToCart(fakeProduct_1, 3);
            var result = cartService.GetTotalQuantity();

            // Assert
            Assert.Equal(2,result);

        }
        #region Decrease
        [Fact]
        public void DecreaseQuantity_DecreasesQuantityWhenGreaterThanOne()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product { Id = 1, Name = "TestProduct", Price = 10.99 };
            cartService.AddToCart(product, 3);

            // Act
            cartService.DecreaseQuantity(product, 2);

            // Assert
            Assert.Equal(1, cartService.GetTotalQuantity());
        }

        [Fact]
        public void DecreaseQuantity_RemovesProductWhenQuantityIsOne()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product { Id = 1, Name = "TestProduct", Price = 10.99 };
            cartService.AddToCart(product, 1);

            // Act
            cartService.DecreaseQuantity(product, 1);

            // Assert
            Assert.Empty(cartService.GetCartItems());
        }

        [Fact]
        public void DecreaseQuantity_DoesNothingWhenProductNotFound()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product { Id = 1, Name = "TestProduct", Price = 10.99 };

            // Act
            cartService.DecreaseQuantity(product, 1);

            // Assert
            // Ensure no exception is thrown and cart remains empty
            Assert.Empty(cartService.GetCartItems());
        }
        #endregion
    }
}

