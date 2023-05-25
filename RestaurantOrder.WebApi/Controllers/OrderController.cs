using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Service.DTOs.Orders;
using RestaurantOrder.Service.Responses;
using RestaurantOrder.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderService _orderService;
        readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("byarea/{areaId:guid}")]
        [ProducesResponseType(typeof(ICollection<ViewOrderDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetOrdersByArea([FromRoute] Guid areaId)
        {
            ServiceResult<ICollection<Order>> result =
                await _orderService.GetAllOrdersByArea(areaId);

            var ordersDTO = _mapper.Map<ICollection<ViewOrderDTO>>(result.Data);

            return StatusCode(result.StatusCode, ordersDTO);
        }


        [HttpGet("oldest/{areaId:guid}")]
        [ProducesResponseType(typeof(ViewOrderDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetOldestOrdersByArea([FromRoute] Guid areaId)
        {
            ServiceResult<Order> result =
                await _orderService.GetOldestByArea(areaId);

            var ordersDTO = _mapper.Map<ViewOrderDTO>(result.Data);

            return StatusCode(result.StatusCode, ordersDTO);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ViewOrderDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
        {
            throw new Exception();

            var order = _mapper.Map<Order>(dto);

            ServiceResult<Order> result = await _orderService.CreateOrder(order);

            if (result.Failure) return StatusCode(result.StatusCode, result);

            var viewOrderDto = _mapper.Map<ViewOrderDTO>(result.Data);

            return StatusCode(result.StatusCode, viewOrderDto);
        }
    }
}
