﻿using FluentValidation.Results;

namespace RestaurantOrder.Domain.Extensions
{
    public static class FluentValidationExtension
    {
        public static void AddErrors(this ValidationResult validationResult, ValidationResult otherValidationResult)
        {
            foreach (var error in otherValidationResult.Errors)
            {
                validationResult.Errors.Add(error);
            }
        }
    }
}
