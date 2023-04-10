using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto = SalesOrder.BLL.Models;

namespace SalesOrder.BLL.Contracts
{
    public interface IElementsBL
    {
        public Task<List<Dto.Element>> GetAll(int windowId);
        public Task Create(Dto.Element element);
        public Task Update(Dto.Element element);
        public Task Delete(int elementId);
    }
}
