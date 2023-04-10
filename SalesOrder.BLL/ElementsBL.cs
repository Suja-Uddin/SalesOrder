using Microsoft.EntityFrameworkCore;
using SalesOrder.BLL.Contracts;
using SalesOrder.DAL;
using SalesOrder.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto = SalesOrder.BLL.Models;

namespace SalesOrder.BLL
{
    public class ElementsBL : IElementsBL
    {
        private SalesOrderDbContext _context;

        public ElementsBL(SalesOrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dto.Element>> GetAll(int windowId)
        {
            return await _context.Elements
                .Where(e => e.WindowId == windowId)
                .Select(e => new Dto.Element
                {
                    Id = e.ElementId,
                    Number = e.Number,
                    Type = e.Type,
                    Height = e.Height,
                    Width = e.Width,
                    WindowId = e.WindowId
                }).ToListAsync();
        }

        public async Task Create(Models.Element element)
        {
            _context.Add(new Element
            {
                ElementId = element.Id,
                Number = element.Number,
                Type = element.Type,
                Height = element.Height,
                Width = element.Width,
                WindowId = element.WindowId
            });

            await _context.SaveChangesAsync();
        }

        public async Task Update(Models.Element element)
        {
            var dbItem = await _context.Elements.Where(e => e.ElementId == element.Id).FirstOrDefaultAsync();
            dbItem.Number = element.Number;
            dbItem.WindowId = element.WindowId;
            dbItem.Type = element.Type;
            dbItem.Height = element.Height;
            dbItem.Width = element.Width;

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int elementId)
        {
            var element = await _context.Elements.FirstOrDefaultAsync(e => e.ElementId == elementId);
            _context.Elements.Remove(element);

            await _context.SaveChangesAsync();
        }
    }
}
