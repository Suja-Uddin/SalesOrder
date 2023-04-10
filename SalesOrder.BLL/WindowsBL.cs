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
    public class WindowsBL : IWindowsBL
    {
        private SalesOrderDbContext _context;

        public WindowsBL(SalesOrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dto.Window>> GetAll(int orderId)
        {
            return await _context.Windows
                .Where(w => w.OrderId == orderId)
                .Select(w => new Dto.Window
                {
                    Id = w.WindowId,
                    Name = w.Name,
                    Quantity = w.Quantity,
                    OrderId = w.OrderId
                }).ToListAsync();
        }

        public async Task Create(Dto.Window window)
        {
            _context.Windows.Add(new Window
            {
                WindowId = window.Id,
                Name = window.Name,
                Quantity = window.Quantity,
                OrderId = window.OrderId
            });

            await _context.SaveChangesAsync();
        }

        public async Task Update(Dto.Window window)
        {
            var dbItem = await _context.Windows.Where(w => w.WindowId == window.Id).FirstOrDefaultAsync();
            dbItem.OrderId = window.OrderId;
            dbItem.Name = window.Name;
            dbItem.Quantity = window.Quantity;
            
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int windowId)
        {
            var window = await _context.Windows.FirstOrDefaultAsync(w => w.WindowId== windowId);
            _context.Windows.Remove(window);

            await _context.SaveChangesAsync();
        }
    }
}
