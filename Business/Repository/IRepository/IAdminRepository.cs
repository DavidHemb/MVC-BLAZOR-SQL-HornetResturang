using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IAdminRepository
    {
        public IEnumerable<OrderDTO> GetAllOrders();
    }
}
