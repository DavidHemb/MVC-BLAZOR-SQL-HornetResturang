using Business.Repository.IRepository;
using DataAccess.Models;
using FakeItEasy;
using FakeItEasy.Configuration;
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
    public class CategoryControllerTest
    {
        private CategoryController _categoryController;
        private ICategoryRepository _categoryRepository;
        public CategoryControllerTest()
        {
            //Dependencies
            _categoryRepository = A.Fake<ICategoryRepository>();

            //SUT
            _categoryController = new CategoryController(_categoryRepository);
        }

        [Fact]
        public void CategoryController_GetAll_ReturnSuccess()
        {
            //Arrange
            var category = A.Fake<IEnumerable<Category>>();
            A.CallTo(() => _categoryRepository.GetAll()).Returns(category);
            //Act
            var result = _categoryController.GetAll();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void CategoryController_GetAllWithProducts_ReturnSuccess()
        {
            //Arrange
            var category = A.Fake<IEnumerable<Category>>();
            A.CallTo(() => _categoryRepository.GetAllWithProducts()).Returns(category);
            //Act
            var result = _categoryController.GetAllWithProducts();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void CategoryController_GetByCategoryId_ReturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var category = A.Fake<Category>();
            A.CallTo(() => _categoryRepository.GetByCategoryId(id)).Returns(category);
            //Act
            var result = _categoryController.GetByCategoryId(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void CategoryController_Create_ReturnSuccess()
        {
            //Arrange
            var category = A.Fake<Category>();
            A.CallTo(() => _categoryRepository.Create(category)).Returns(category);
            //Act
            var result = _categoryController.Create(category);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void CategoryController_Delete_ReturnSuccess()
        {
            //Arrange
            var id = 1234567890;
            var category = A.Fake<Category>();
            A.CallTo(() => _categoryRepository.Delete(category));
            //Act
            var result = _categoryController.Delete(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void CategoryController_Update_ReturnSuccess()
        {
            //Arrange
            var category = A.Fake<Category>();
            A.CallTo(() => _categoryRepository.Update(category));
            //Act
            var result = _categoryController.Update(category);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
