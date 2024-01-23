using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;

namespace Business.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public CustomerDTO Create(CustomerDTO objDTO)
        {
            var obj = _mapper.Map<CustomerDTO, Customer>(objDTO);
            var addedObj = _appDbContext.Customers.Add(obj);
            _appDbContext.SaveChanges();

            return _mapper.Map<Customer, CustomerDTO>(addedObj.Entity);
        }

        public CustomerDTO Delete(string id)
        {
            var obj = _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (obj != null)
            {
                _appDbContext.Customers.Remove(obj);
                _appDbContext.SaveChanges();
                return new CustomerDTO
                {
                    Id = obj.Id,
                    Email = obj.Email,
                    UserName = obj.UserName,
                    PhoneNumber = obj.PhoneNumber
                };
            }
            return null;
        }

        public CustomerDTO Get(string id)
        {
            var obj = _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Customer, CustomerDTO>(obj);
            }
            return new CustomerDTO();
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(_appDbContext.Customers);
        }

        public CustomerDTO Update(CustomerDTO objDTO)
        {
            var objFromDb = _appDbContext.Customers.FirstOrDefault(c => c.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.UserName = objDTO.UserName;
                _appDbContext.Customers.Update(objFromDb);
                _appDbContext.SaveChanges();
                return _mapper.Map<Customer, CustomerDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
