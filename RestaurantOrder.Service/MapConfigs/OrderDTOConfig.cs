using AutoMapper;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Service.DTOs.Orders;

namespace RestaurantOrder.Service.MapConfigs
{
    public class OrderDTOConfig : Profile
    {
        public OrderDTOConfig()
        {
            MapDomainToDTO();
            MapDTOToDomain();
        }

        private void MapDTOToDomain()
        {
            CreateMap<CreateItemOrderDTO, ItemOrder>();
            CreateMap<CreateOrderDTO, Order>();
        }

        private void MapDomainToDTO()
        {
            CreateMap<ItemOrder, ViewItemOrderDTO>();
            CreateMap<Order, ViewOrderDTO>();
        }
    }
}
