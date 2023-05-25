using RestaurantOrder.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Domain.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(Guid id);
        Task<ICollection<Order>> GetAllByAreaIdAsync(Guid areaId);
        Task InsertAsync(Order order);
        Task<Order> GetOldestByArea(Guid areaId);
    }
}
