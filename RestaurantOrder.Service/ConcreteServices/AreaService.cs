using AutoMapper;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Domain.Repositories.Orders;
using RestaurantOrder.Service.DTOs.Responses;
using RestaurantOrder.Service.Responses;
using RestaurantOrder.Service.ServicesInterfaces;
using System.Threading.Tasks;

namespace RestaurantOrder.Service.ConcreteServices
{
    public class AreaService : IAreaService
    {
        readonly IAreaRepository _areaRepository;
        readonly IMapper _mapper;

        public AreaService(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResult<Area>> CreateArea(Area area)
        {
            if (!area.IsValid())
                return ServiceResultFactory<Area>.BadRequest(_mapper.Map<ValidationFailureDTO>(area.GetInvalidDataError()), "Invalid Object");

            await _areaRepository.InsertAsync(area);

            return ServiceResultFactory<Area>.Ok(area);
        }

        public async Task<ServiceResult<Area>> GetAreaByName(string name)
        {
            Area area = await _areaRepository.GetByNameAsync(name);

            return ServiceResultFactory<Area>.Ok(area);
        }
    }
}
