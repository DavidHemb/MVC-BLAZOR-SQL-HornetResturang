using DataAccess.Models;
using FakeItEasy;
using Hornet.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hornet.Test.ServicesTest
{
    public class OrderProductsServiceTest
    {
        private readonly OrderProductsService _opService;
        public OrderProductsServiceTest()
        {
            _opService = A.Fake<OrderProductsService>();
        }

        [Fact]
        public async Task OrderProductsService_GetAll_ReturnNotNull()
        {
            var list = _opService.GetAll();
            Assert.NotNull(list);
        }
    }
}
