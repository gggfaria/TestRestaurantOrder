using FluentValidation;
using RestaurantOrder.Domain.Entities.Orders;

namespace RestaurantOrder.Domain.Validators
{
    class ItemOrderValidator : AbstractValidator<ItemOrder>
    {
        public ItemOrderValidator()
        {
            ValidateAmout();
        }

        private void ValidateAmout()
        {
            RuleFor(p => p.Amount)
                .GreaterThanOrEqualTo(ItemOrder.MIN_AMOUNT)
                .LessThanOrEqualTo(ItemOrder.MAX_AMOUNT);
        }
    }
}
