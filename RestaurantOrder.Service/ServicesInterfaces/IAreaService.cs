using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Service.Responses;
using System.Threading.Tasks;

namespace RestaurantOrder.Service.ServicesInterfaces
{
    public interface IAreaService
    {
        Task<ServiceResult<Area>> CreateArea(Area area);
        Task<ServiceResult<Area>> GetAreaByName(string name);
    }
}
