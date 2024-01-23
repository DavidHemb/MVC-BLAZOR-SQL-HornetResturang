using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Identity;

namespace Business.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<bool> Create(Employee user);
        public Task<EmployeeDTO> Update(EmployeeDTO objDTO);
        public Task<bool> DeleteUserById(string id);
        public EmployeeDTO GetDTOById(string id);
        public Task<Employee> GetById(string id);
        public Task<IEnumerable<EmployeeDTO>> GetAll();

    }
}
