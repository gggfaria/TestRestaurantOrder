using AutoMapper;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.Domain.Repositories.Orders;
using RestaurantOrder.Service.DTOs.Responses;
using RestaurantOrder.Service.Responses;
using RestaurantOrder.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Service.ConcreteServices
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepository;
        readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResult<Order>> CreateOrder(Order order)
        {
            if (!order.IsValid())
                return ServiceResultFactory<Order>.BadRequest(_mapper.Map<ICollection<ValidationFailureDTO>>(order.GetInvalidDataError()), "Invalid Object");

            await _orderRepository.InsertAsync(order);

            return ServiceResultFactory<Order>.Ok(order);
        }

        public async Task<ServiceResult<ICollection<Order>>> GetAllOrdersByArea(Guid areaId)
        {
            ICollection<Order> orders = await _orderRepository.GetAllByAreaIdAsync(areaId);

            return ServiceResultFactory<ICollection<Order>>.Ok(orders);
        }

        public async Task<ServiceResult<Order>> GetOldestByArea(Guid areaId)
        {
            Order orders = await _orderRepository.GetOldestByArea(areaId);

            return ServiceResultFactory<Order>.Ok(orders);
        }
    }
}
