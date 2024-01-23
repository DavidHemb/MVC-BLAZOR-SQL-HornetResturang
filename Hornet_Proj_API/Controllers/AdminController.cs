using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Hornet_Proj_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public AdminController(IAdminRepository adminRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _adminRepository = adminRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_adminRepository.GetAllOrders());
        }
    }
}
