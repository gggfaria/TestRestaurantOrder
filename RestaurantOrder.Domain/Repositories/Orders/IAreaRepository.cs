using RestaurantOrder.Domain.Entities.Orders;
using System.Threading.Tasks;

namespace RestaurantOrder.Domain.Repositories.Orders
{
    public interface IAreaRepository
    {
        Task InsertAsync(Area area);
        Task<Area> GetByNameAsync(string name);
    }
}
