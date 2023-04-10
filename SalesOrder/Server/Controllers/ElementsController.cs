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
    [Route("api/Windows/{windowId}/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private IElementsBL _elementsBL;
        public ElementsController(IElementsBL elementsBL)
        {
            _elementsBL = elementsBL;
        }

        [HttpGet]
        public async Task<object> GetAllElementsAsync(int windowId)
        {
            var elements = await _elementsBL.GetAll(windowId);
            return new
            {
                Items = elements.Select(elem => new Element
                {
                    Id = elem.Id,
                    Number = elem.Number,
                    Height = elem.Height,
                    Width = elem.Width,
                    Type = elem.Type
                }),
                Count = elements.Count()
            };
        }

        [HttpPost]
        public async Task CreateElementAsync(int windowId, [FromBody] Element element)
        {
            await _elementsBL.Create(new Dto.Element
            {
                Number = element.Number,
                Type = element.Type,
                Height = element.Height,
                Width = element.Width,
                WindowId = windowId
            });
        }

        [HttpPut("{id}")]
        public async Task UpdateElementAsync(int windowId, int id, [FromBody] Element element)
        {
            await _elementsBL.Update(new Dto.Element
            {
                Id = id,
                Number = element.Number,
                Type = element.Type,
                Height = element.Height,
                Width = element.Width,
                WindowId = windowId
            });
        }

        [HttpDelete("{id}")]
        public async Task DeleteElementAsync(int id)
        {
            await _elementsBL.Delete(id);
        }
    }
}
