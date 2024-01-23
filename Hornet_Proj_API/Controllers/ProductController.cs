using Business.Repository.IRepository;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hornet_Proj_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productRepository.GetAll());
        }
        [HttpGet("{productId}")]
        public IActionResult GetByProductId(int productId)
        {
            return Ok(_productRepository.GetByProductId(productId));
        }
        [HttpGet("GetByName")]
        public IActionResult GetByProductName(string productName)
        {
            return Ok(_productRepository.GetByProductName(productName));
        }

        [HttpGet("GetMostSoldProducts")]
        public IActionResult GetMostSoldProducts()
        {
            return Ok(_productRepository.GetMostSoldProducts());
        }
        [HttpGet("GetProductsByOrderId/{orderId}")]
        public IActionResult GetProductsByOrderId(int orderId)
        {
            return Ok(_productRepository.GetProductsByOrderId(orderId));
        }

        [HttpPost("Create")]
        public IActionResult Create(Product obj)
        {
            return Ok(_productRepository.Create(obj));
        }
        [HttpPut("Update")]
        public IActionResult Update(Product obj)
        {
            return Ok(_productRepository.Update(obj));
        }
        [HttpDelete("Delete/{productid}")]
        public IActionResult Delete(int productid)
        {
            var product = _productRepository.GetByProductId(productid);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_productRepository.Delete(product));
        }
    }
}
