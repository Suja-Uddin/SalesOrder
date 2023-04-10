using SalesOrder.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto = SalesOrder.BLL.Models;

namespace SalesOrder.BLL.Contracts
{
    public interface IWindowsBL
    {
        public Task<List<Dto.Window>> GetAll(int orderId);
        public Task Create(Dto.Window window);
        public Task Update(Dto.Window window);
        public Task Delete(int windowId);
    }
}
