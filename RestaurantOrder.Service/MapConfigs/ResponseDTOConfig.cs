using AutoMapper;
using FluentValidation.Results;
using RestaurantOrder.Service.DTOs.Responses;

namespace RestaurantOrder.Service.MapConfigs
{
    public class ResponseDTOConfig : Profile
    {
        public ResponseDTOConfig()
        {
            CreateMap<ValidationFailure, ValidationFailureDTO>();
        }
    }
}
