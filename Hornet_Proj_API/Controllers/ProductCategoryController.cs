using Business.Repository.IRepository;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hornet_Proj_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            return Ok(_productRepository.GetProductsByCategoryId(id));
        }
        [HttpGet]
        public IActionResult GetProductCategories()
        {
            return Ok(_productCategoryRepository.GetProductCategories());
        }
        [HttpPost("Create")]
        public IActionResult Create(ProductCategory prodcat)
        {
            return Ok(_productCategoryRepository.Create(prodcat));
        }
    }
}
