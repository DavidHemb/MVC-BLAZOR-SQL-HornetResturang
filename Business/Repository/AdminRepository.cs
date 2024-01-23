using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AdminRepository(AppDbContext appDbContext, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orders = _appDbContext.OrderProducts
              .Include(op => op.Product)
              .Include(op => op.Order)
              .Select(op => new OrderDTO
              {
                  OrderProduct = op,
                  Order = op.Order,
                  Product = op.Product,
                  Customer = _userManager.Users
                  .Where(x => x.Id == op.Order.CustomerId)
                  .Select(user => _mapper.Map<CustomerDTO>(user))
                  .FirstOrDefault()
              })
              .ToList();

            return orders;
        }
    }
}
