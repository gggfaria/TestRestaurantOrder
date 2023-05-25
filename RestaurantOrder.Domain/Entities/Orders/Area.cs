using FluentValidation.Results;
using RestaurantOrder.Domain.Validators;
using System.Collections.Generic;

namespace RestaurantOrder.Domain.Entities.Orders
{
    public class Area : EntityBase
    {
        public Area(string name)
        {
            Name = name.Trim();
        }

        protected Area() { }

        public string Name { get; private set; }
        public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();

        public override bool IsValid()
        {
            var validator = new AreaValidator();
            ValidationResult validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
                ValidationResult = validationResult;

            return ValidationResult.IsValid;
        }
    }
}
