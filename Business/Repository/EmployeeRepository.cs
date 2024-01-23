using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;


        public EmployeeRepository(AppDbContext appDbContext, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Create(Employee user)
        {
            // Ensure that the user is not null. 
            if (user == null)
            {
                return false;
            }

            // Check if the username is already taken.
            var existingUser = await _userManager.FindByNameAsync(user.UserName);
            if (existingUser != null)
            {
                return false;
            }

            // Create User
            try
            {
                var addedUser = await _userManager.CreateAsync(user);

                if (addedUser.Succeeded)
                {
                    //If create is successfull, add the Role
                    await _userManager.AddToRoleAsync(user, "Employee");
                    //Save Changes
                    await _appDbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> PromoteToEmployee(Employee obj)
        {
            var result = await _userManager.AddToRoleAsync(obj, "Employee");
            return result.Succeeded ? Save() : false;
        }

        public async Task<bool> PromoteToAdmin(Employee obj)
        {
            if (await _userManager.IsInRoleAsync(obj, "Employee"))
            {
                var removeModRole = await _userManager.RemoveFromRoleAsync(obj, "Employee");
            }

            var result = await _userManager.AddToRoleAsync(obj, "Admin");
            return result.Succeeded ? Save() : false;
        }

        public async Task<bool> DemoteToMember(Employee obj)
        {
            if (await _userManager.IsInRoleAsync(obj, "Employee"))
            {
                var result = await _userManager.RemoveFromRoleAsync(obj, "Employee");
                return result.Succeeded ? Save() : false;
            }
            if (await _userManager.IsInRoleAsync(obj, "Admin"))
            {
                var result = await _userManager.RemoveFromRoleAsync(obj, "Admin");
                return result.Succeeded ? Save() : false;
            }
            return false;
        }

        public async Task<bool> DeleteUserById(string id)
        {
            var employee = await GetById(id);

            if (employee != null)
            {

                var user = await _userManager.FindByIdAsync(employee.Id);

                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        Save();
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<Employee> GetById(string id)
        {
            var user = _userManager.Users
                .Where(u => u.Id == id)
                .Select(u => _mapper.Map<Employee>(u))
                .FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public EmployeeDTO GetDTOById(string id)
        {
            var user = _userManager.Users
                .Where(u => u.Id == id)
                .Select(u => _mapper.Map<EmployeeDTO>(u))
                .FirstOrDefault();
            if (user != null)
            {
                var employeeDTO = _mapper.Map<EmployeeDTO>(user);
                return employeeDTO;
            }
            return null;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var employeesInRole = new List<IdentityUser>();

            // Get all users
            var allUsers = await _userManager.Users.ToListAsync();

            // Iterate over each user and check if they have the role 'Employee'.
            foreach (var user in allUsers)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, "Employee");

                if (isInRole)
                {
                    employeesInRole.Add(user);
                }
            }

            // Map too EmployeeDTO and return the result
            var employeeDTOs = employeesInRole.Select(user => _mapper.Map<EmployeeDTO>(user)).ToList();
            return employeeDTOs;
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO objDTO)
        {
            var existingEmployee = _appDbContext.Employees.FirstOrDefault(e => e.Id == objDTO.Id);

            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.Id = objDTO.Id;
            if (existingEmployee.UserName != objDTO.UserName)
            {
                existingEmployee.UserName = objDTO.UserName + "@mail.com";
                existingEmployee.Email = objDTO.UserName + "@mail.com";
            }
            existingEmployee.PhoneNumber = objDTO.PhoneNumber;
            existingEmployee.Department = objDTO.Department;

            _appDbContext.Employees.Update(existingEmployee);
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<Employee, EmployeeDTO>(existingEmployee);
        }
        private bool Save()
        {
            try
            {
                _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
