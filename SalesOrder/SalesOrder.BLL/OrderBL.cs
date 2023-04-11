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
    public class OrderBL : IOrderBL
    {
        private SalesOrderDbContext _context;

        public OrderBL(SalesOrderDbContext context)
        {
            _context = context;
        }

        public async Task Create(Dto.Order order)
        {
            _context.Orders.Add(new Order
            {
                Name = order.Name,
                State = order.State
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<Dto.Order>> GetAll()
        {
            var orders = await (from o in _context.Orders
                          join w in _context.Windows on o.OrderId equals w.OrderId into wgrp
                          from w in wgrp.DefaultIfEmpty()
                          group w by new
                          {
                              Id = o.OrderId,
                              Name = o.Name,
                              State = o.State
                          } into grp
                          select new Dto.Order
                          {
                              Id = grp.Key.Id,
                              Name = grp.Key.Name,
                              State = grp.Key.State,
                              WindowsCount = grp.Where(w => w != null).Count()
                          }).ToListAsync();
            return orders;
        }

        public async Task Update(Dto.Order order)
        {
            var dbItem = await _context.Orders.Where(o => o.OrderId == order.Id).FirstOrDefaultAsync();
            dbItem.Name = order.Name;
            dbItem.State = order.State;

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}
