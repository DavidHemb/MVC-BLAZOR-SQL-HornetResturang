using Business.Repository;
using Business.Repository.IRepository;
using DataAccess.Models;
using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using Hornet_Models.ModelsDTO;
using Hornet_Proj_API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Hornet.Test.ControllerTest
{
    public class AdminControllerTest
    {
        private AdminController _adminController;
        private IAdminRepository _adminRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        public AdminControllerTest()
        {
            //Dependencies
            _adminRepository = A.Fake<IAdminRepository>();
            _productRepository = A.Fake<IProductRepository>();
            _orderRepository = A.Fake<IOrderRepository>();

            //SUT
            _adminController = new AdminController(_adminRepository, _productRepository, _orderRepository);
        }

        [Fact]
        public void AdminController_GetAll_ReturnTrue()
        {
            var order = A.Fake<IEnumerable<OrderDTO>>();
            A.CallTo(() => _adminRepository.GetAllOrders()).Returns(order);
            //Act
            var result = _adminController.GetAll();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
