using Business.Repository.IRepository;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace Hornet_Proj_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("Delete/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(string employeeId)
        {
            var success = await _employeeRepository.DeleteUserById(employeeId);

            if (success)
            {
                return Ok("användaren är borttagen");
            }
            return NotFound("Användaren kunde inte hittas eller kunde ej tas bort.");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            //var userManager = HttpContext.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
            var success = await _employeeRepository.Create(employee);

            if (!success)
            {
                return NotFound("Användaren kunde inte läggas till");
            }
            return Ok("Användaren är Tillagd");
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
                Console.WriteLine($"Validation errors: {string.Join(", ", errors)}");
                return BadRequest("Invalid model");
            }
            var success = await _employeeRepository.Update(employeeDTO);

            if (success == null)
            {
                return NotFound("Användaren kunde inte hittas / uppdateras");
            }
            return Ok("Användaren uppdaterad");
        }
    }
}
