using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Domain.Repositories.Orders;
using RestaurantOrder.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.EFCore.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantOrderContext _contex;
        public OrderRepository(RestaurantOrderContext contex)
        {
            _contex = contex;
        }

        public async Task<Order> GetAsync(Guid id)
        {
            IQueryable<Order> query = _contex.Orders.AsQueryable();
            return await query.SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<ICollection<Order>> GetAllByAreaIdAsync(Guid areaId)
        {
            IQueryable<Order> query = _contex.Orders.AsQueryable();
            return await query.Where(p => p.AreaId == areaId && p.IsActive)
                .OrderBy(p => p.CreationDate)
                .Include(p => p.ItemOrder)
                .ToListAsync();
        }

        public async Task<Order> GetOldestByArea(Guid areaId)
        {
            IQueryable<Order> query = _contex.Orders.AsQueryable();
            return await query.Where(p => p.AreaId == areaId && p.IsActive)
                .OrderByDescending(p => p.CreationDate)
                .Include(p => p.ItemOrder)
                .SingleOrDefaultAsync();
        }

        public async Task InsertAsync(Order order)
        {
            _contex.Orders.Add(order);
            await _contex.SaveChangesAsync();
        }

    }

}
