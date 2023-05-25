using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Service.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Service.ServicesInterfaces
{
    public interface IOrderService
    {
        Task<ServiceResult<ICollection<Order>>> GetAllOrdersByArea(Guid areaId);
        Task<ServiceResult<Order>> CreateOrder(Order order);
        Task<ServiceResult<Order>> GetOldestByArea(Guid areaId);
    }
}
