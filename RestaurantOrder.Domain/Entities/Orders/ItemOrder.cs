using FluentValidation.Results;
using RestaurantOrder.Domain.Validators;
using System;

namespace RestaurantOrder.Domain.Entities.Orders
{
    public class ItemOrder : EntityBase
    {
        public const int MIN_AMOUNT = 1;
        public const int MAX_AMOUNT = int.MaxValue;

        public ItemOrder(string productName, int amount, decimal unitPrice)
        {
            ProductName = productName;
            Amount = amount;
            UnitPrice = unitPrice;
        }

        protected ItemOrder() { }

        public string ProductName { get; private set; }
        public int Amount { get; private set; }
        public decimal UnitPrice { get; private set; }

        public Order Order { get; private set; }
        public Guid OrderId { get; private set; }

        public override bool IsValid()
        {
            var validator = new ItemOrderValidator();
            ValidationResult validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
                ValidationResult = validationResult;

            return ValidationResult.IsValid;
        }
    }
}
