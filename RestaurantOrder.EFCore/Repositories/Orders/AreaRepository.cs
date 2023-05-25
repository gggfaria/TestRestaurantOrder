using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Domain.Repositories.Orders;
using RestaurantOrder.EFCore.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.EFCore.Repositories.Orders
{
    public class AreaRepository : IAreaRepository
    {
        private readonly RestaurantOrderContext _contex;

        public AreaRepository(RestaurantOrderContext contex)
        {
            _contex = contex;
        }

        public async Task InsertAsync(Area area)
        {
            _contex.Areas.Add(area);
            await _contex.SaveChangesAsync();
        }

        public async Task<Area> GetByNameAsync(string name)
        {
            return await _contex.Areas.FirstOrDefaultAsync(p => p.Name == name.Trim());
        }
    }
}
