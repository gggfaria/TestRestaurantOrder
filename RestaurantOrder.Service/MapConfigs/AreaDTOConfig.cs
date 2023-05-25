using AutoMapper;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Service.DTOs.Areas;

namespace RestaurantOrder.Service.MapConfigs
{
    public class AreaDTOConfig : Profile
    {
        public AreaDTOConfig()
        {
            MapDomainToDTO();
            MapDTOToDomain();
        }

        private void MapDTOToDomain()
        {
            CreateMap<CreateAreaDTO, Area>();
        }

        private void MapDomainToDTO()
        {
            CreateMap<Area, ViewAreaDTO>();
        }
    }
}
