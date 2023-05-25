using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Service.DTOs.Areas;
using RestaurantOrder.Service.Responses;
using RestaurantOrder.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        readonly IAreaService _areaService;
        readonly IMapper _mapper;

        public AreaController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpGet("{area}")]
        [ProducesResponseType(typeof(ICollection<ViewAreaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAreaByName([FromRoute] string area)
        {
            ServiceResult<Area> result =
                await _areaService.GetAreaByName(area);

            var dto = _mapper.Map<ViewAreaDTO>(result.Data);

            return StatusCode(result.StatusCode, dto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ViewAreaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateArea([FromBody] CreateAreaDTO dto)
        {
            var area = _mapper.Map<Area>(dto);

            ServiceResult<Area> result = await _areaService.CreateArea(area);

            if (result.Failure) return StatusCode(result.StatusCode, result);

            var viewAreaDTO = _mapper.Map<ViewAreaDTO>(result.Data);

            return StatusCode(result.StatusCode, viewAreaDTO);
        }
    }
}
