using Hornet_Models.ModelsDTO;

namespace Business.Repository.IRepository
{
    public interface ICustomerRepository
    {
        public CustomerDTO Create(CustomerDTO objDTO);
        public CustomerDTO Update(CustomerDTO objDTO);
        public CustomerDTO Delete(string id);
        public CustomerDTO Get(string id);
        public IEnumerable<CustomerDTO> GetAll();
    }
}
