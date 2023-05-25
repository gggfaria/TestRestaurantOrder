using FluentValidation;
using RestaurantOrder.Domain.Entities.Orders;
using System;

namespace RestaurantOrder.Domain.Validators
{
    public class AreaValidator : AbstractValidator<Area>
    {
        public AreaValidator()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
