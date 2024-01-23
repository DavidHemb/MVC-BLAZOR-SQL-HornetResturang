using Business.Repository.IRepository;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hornet_Proj_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryRepository.GetAll());
        }
        [HttpGet("GetAllWithProducts")]
        public IActionResult GetAllWithProducts()
        {
            return Ok(_categoryRepository.GetAllWithProducts());
        }
        [HttpGet("GetAllWithProductsFull")]
        public IActionResult GetAllWithProductsFull()
        {
            return Ok(_categoryRepository.GetAllWithProductsFull());
        }
        [HttpGet("{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            return Ok(_categoryRepository.GetByCategoryId(categoryId));
        }
        [HttpPost("Create")]
        public IActionResult Create(Category obj)
        {
            return Ok(_categoryRepository.Create(obj));
        }
        [HttpDelete("Delete/{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            var category = _categoryRepository.GetByCategoryId(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(_categoryRepository.Delete(category));
        }
        [HttpPut("Update")]
        public IActionResult Update(Category obj)
        {
            return Ok(_categoryRepository.Update(obj));
        }
    }
}
