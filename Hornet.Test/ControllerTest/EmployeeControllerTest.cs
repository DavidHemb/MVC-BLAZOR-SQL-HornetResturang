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
    public class EmployeeControllerTest
    {
        private EmployeeController _employeeController;
        private IEmployeeRepository _employeeRepository;
        public EmployeeControllerTest()
        {
            //Dependencies
            _employeeRepository = A.Fake<IEmployeeRepository>();

            //SUT
            _employeeController = new EmployeeController(_employeeRepository);
        }

        [Fact]
        public void EmployeeController_GetAll_ReturnSuccess()
        {
            //Arrange
            var employees = A.Fake<IEnumerable<EmployeeDTO>>();
            A.CallTo(() => _employeeRepository.GetAll()).Returns(employees);
            //Act
            var result = _employeeController.GetAll();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EmployeeController_Get_ReturnSuccess()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var employees = A.Fake<Employee>();
            A.CallTo(() => _employeeRepository.GetById(id)).Returns(employees);
            //Act
            var result = _employeeController.Get(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EmployeeController_DeleteEmployee_ReturnSuccess()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var employees = A.Fake<Employee>();
            A.CallTo(() => _employeeRepository.DeleteUserById(id));
            //Act
            var result = _employeeController.DeleteEmployee(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EmployeeController_CreateEmployee_ReturnSuccess()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var employee = A.Fake<Employee>();
            A.CallTo(() => _employeeRepository.Create(employee)).Returns(true);
            //Act
            var result = _employeeController.CreateEmployee(employee);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async Task EmployeeController_UpdateEmployee_ReturnSuccess()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var employee = A.Fake<EmployeeDTO>();
            A.CallTo(() => _employeeRepository.Update(employee))
                .ReturnsLazily((IFakeObjectCall call) => Task.FromResult<EmployeeDTO>(new EmployeeDTO()));

            // Act
            var result = await _employeeController.UpdateEmployee(id, employee);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
