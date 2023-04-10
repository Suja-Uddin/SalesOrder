using Microsoft.AspNetCore.Mvc;
using SalesOrder.BLL;
using SalesOrder.BLL.Contracts;
using SalesOrder.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto = SalesOrder.BLL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesOrder.API.Controllers
{
    [Route("api/Orders/{orderId}/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private IWindowsBL _windowsBL;

        public WindowsController(IWindowsBL windowsBL)
        {
            _windowsBL = windowsBL;
        }

        [HttpGet]
        public async Task<object> GetAllWindows(int orderId)
        {
            var windows = await _windowsBL.GetAll(orderId);

            return new
            {
                Items = windows,
                Count = windows.Count()
            };
        }

        [HttpPost]
        public async Task CreateWindow(int orderId, [FromBody] Window window)
        {
            await _windowsBL.Create(new Dto.Window
            {
                Id = window.Id,
                Name = window.Name,
                Quantity = window.Quantity,
                OrderId = orderId
            });
        }

        [HttpPut("{id}")]
        public async Task PutAsync(int orderId, int id, [FromBody] Window window)
        {
            await _windowsBL.Update(new Dto.Window
            {
                Id = id,
                Name = window.Name,
                OrderId = orderId,
                Quantity = window.Quantity
            });
        }
        
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _windowsBL.Delete(id);
        }
    }
}
