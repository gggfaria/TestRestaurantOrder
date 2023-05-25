using FluentValidation;
using RestaurantOrder.Domain.Entities.Orders;
using System;

namespace RestaurantOrder.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.TotalPrice)
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.AreaId)
                .NotNull();
        }
    }
}
