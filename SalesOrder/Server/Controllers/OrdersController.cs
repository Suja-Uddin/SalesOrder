using Microsoft.AspNetCore.Mvc;
using SalesOrder.BLL.Contracts;
using SalesOrder.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto = SalesOrder.BLL.Models;

namespace SalesOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderBL _orderBL;
        public OrdersController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpGet]
        public async Task<object> GetAllOrders()
        {
            var orders = await _orderBL.GetAll();
            return new
            {
                Items = orders.Select(o => new Order
                {
                    Id = o.Id,
                    Name = o.Name,
                    State = o.State,
                    WindowsCount = o.WindowsCount
                }).ToList(),
                Count = orders.Count()
            };
        }

        [HttpPost]
        public Task CreateOrder([FromBody] Order item)
        {
            return _orderBL.Create(new Dto.Order
            {
                Id = item.Id,
                Name = item.Name,
                State = item.State
            });
        }

        [HttpPut("{id}")]
        public Task UpdateOrder(int id, [FromBody] Order item)
        {
            return _orderBL.Update(new Dto.Order
            {
                Id = id,
                Name = item.Name,
                State = item.State
            });
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _orderBL.Delete(id);
        }
    }
}
