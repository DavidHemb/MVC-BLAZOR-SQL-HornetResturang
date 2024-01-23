using Business.Repository.IRepository;
using DataAccess.Models;
using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using Hornet_Models.ModelsDTO;
using Hornet_Proj_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Hornet.Test.ControllerTest
{
    public class OrderControllerTest
    {
        private OrderController _orderController;
        private IOrderRepository _orderRepository;

        public OrderControllerTest()
        {
            //Dependencies
            _orderRepository = A.Fake<IOrderRepository>();

            //SUT
            _orderController = new OrderController(_orderRepository);
        }

        [Fact]
        public void OrderController_GetAll_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<IEnumerable<OrderDTO>>();
            A.CallTo(() => _orderRepository.GetAll()).Returns(order);
            //Act
            var result = _orderController.GetAll();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_GetOrderByOrderId_ReturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var order = A.Fake<OrderDTO>();
            A.CallTo(() => _orderRepository.GetOrderByOrderId(id)).Returns(order);
            //Act
            var result = _orderController.GetOrderByOrderId(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_GetAllById_ReturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var order = new List<OrderDTO> { A.Fake<OrderDTO>() };
            A.CallTo(() => _orderRepository.GetAllById(id)).Returns(order);
            //Act
            var result = _orderController.GetAllById(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_Create_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<CreateOrderDTO>();
            var createdOrder = A.Fake<OrderDTO>();
            A.CallTo(() => _orderRepository.Create(order)).Returns(createdOrder);
            //Act
            var result = _orderController.Create(order);
            //Assert
            result.Should().BeOfType<CreatedAtActionResult>();
        }
        [Fact]
        public void OrderController_Update_ReturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var orderMessage = "Test";
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.UpdateOrderMessage(order));
                
            //Act
            var result = _orderController.Update(id, orderMessage);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_ComfirmOrder_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.ConfirmOrder(order));
            //Act
            var result = _orderController.ConfirmOrder(order);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_UpdateIsTakeAway_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.UpdateIsTakeAway(order));
            //Act
            var result = _orderController.UpdateIsTakeAway(order);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_UpdateIsReady_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.UpdateIsTakeAway(order));
            //Act
            var result = _orderController.UpdateIsTakeAway(order);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_UpdateOrderProducts_ReturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var productorder = A.Fake<List<OrderProductDTO>>();
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.UpdateOrderProducts(id, productorder));
            //Act
            var result = _orderController.UpdateOrderProducts(id, productorder);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_UpdateOrderMessage_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.UpdateOrderMessage(order));
            //Act
            var result = _orderController.UpdateOrderMessage(order);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void OrderController_DeleteOrder_ReturnSuccess()
        {
            //Arrange
            var order = A.Fake<Order>();
            A.CallTo(() => _orderRepository.DeleteOrder(order));
            //Act
            var result = _orderController.DeleteOrder(order);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
