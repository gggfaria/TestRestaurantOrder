using FluentValidation.Results;
using RestaurantOrder.Domain.Extensions;
using RestaurantOrder.Domain.Validators;
using System;
using System.Collections.Generic;

namespace RestaurantOrder.Domain.Entities.Orders
{
    public class Order : EntityBase
    {
        public Order(string code, int totalPrice, ICollection<ItemOrder> itemOrder, Area area, Guid areaId)
        {
            Code = code;
            TotalPrice = totalPrice;
            ItemOrder = itemOrder;
            Area = area;
            AreaId = areaId;
        }

        protected Order() { }

        public string Code { get; set; }
        public int TotalPrice { get; private set; }
        public ICollection<ItemOrder> ItemOrder { get; private set; }
        public Area Area { get; private set; }
        public Guid AreaId { get; private set; }

        public override bool IsValid()
        {
            var validatorOrder = new OrderValidator();
            ValidateItemOrder();

            ValidationResult alunoValidationResult = validatorOrder.Validate(this);

            if (!alunoValidationResult.IsValid)
                ValidationResult = alunoValidationResult;

            return ValidationResult.IsValid;
        }

        private void ValidateItemOrder()
        {
            foreach (var item in ItemOrder)
            {
                if (!item.IsValid())
                    ValidationResult.AddErrors(item.ValidationResult);
            }
        }

    }
}
