using System;
using System.Threading.Tasks;
using Hornet_Proj_Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HornetTest
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public async Task Create_ValidUser_ReturnsTrue()
        {
            //Arrange
            var userManagerMock = new Mock<IUserManager>();
            var appDbContextMock = new Mock<IAppDbContext>();
            //Act
            //Assert
        }
    }
}
