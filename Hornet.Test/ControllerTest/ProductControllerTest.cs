using Business.Repository.IRepository;
using DataAccess.Models;
using FakeItEasy;
using FluentAssertions;
using Hornet_Proj_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hornet.Test.ControllerTest
{
    public class ProductControllerTest
    {
        private ProductController _productController;
        private IProductRepository _productRepository;
        public ProductControllerTest()
        {
            //Dependencies
            _productRepository = A.Fake<IProductRepository>();

            //Sut
            _productController = new ProductController(_productRepository);
        }
        [Fact]
        public void ProductController_GetAll_ResturnSuccess()
        {
            //Arrange
            var product = A.Fake<IEnumerable<Product>>();
            A.CallTo(() => _productRepository.GetAll()).Returns(product); 
            //Act
            var result = _productController.GetAll();
            //Assert 
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void ProductController_GetByProductId_ResturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var product = A.Fake<Product>();
            A.CallTo(() => _productRepository.GetByProductId(id)).Returns(product);
            //Act
            var result = _productController.GetByProductId(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void ProductController_GetMostSoldProducts_ResturnSuccess()
        {
            //Arrange
            var products = A.Fake<IEnumerable<Product>>();
            A.CallTo(() => _productRepository.GetMostSoldProducts());
            //Act
            var result = _productController.GetMostSoldProducts();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void ProductController_GetProductsByOrderId_ResturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var product = A.Fake<Product>();
            A.CallTo(() => _productRepository.GetProductsByOrderId(id));
            //Act
            var result = _productController.GetProductsByOrderId(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void ProductController_Create_ResturnSuccess()
        {
            //Arrange
            var product = A.Fake<Product>();
            A.CallTo(() => _productRepository.Create(product));
            //Act
            var result = _productController.Create(product);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void ProductController_Update_ResturnSuccess()
        {
            //Arrange
            var product = A.Fake<Product>();
            A.CallTo(() => _productRepository.Update(product));
            //Act
            var result = _productController.Update(product);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void ProductController_Delete_ResturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var product = A.Fake<Product>();
            A.CallTo(() => _productRepository.Delete(product));
            //Act
            var result = _productController.Delete(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
