using SalesOrder.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto = SalesOrder.BLL.Models;

namespace SalesOrder.BLL.Contracts
{
    public interface IOrderBL
    {
        public Task<List<Dto.Order>> GetAll();
        public Task Create(Dto.Order order);
        public Task Update(Dto.Order order);
        public Task Delete(int OrderId);
    }
}
