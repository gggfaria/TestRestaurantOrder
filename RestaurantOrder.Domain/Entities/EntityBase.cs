using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace RestaurantOrder.Domain.Entities
{
    /// <summary>
    /// Entity base for all domain's entity
    /// </summary>
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreationDate = DateTime.UtcNow;
            ValidationResult = new ValidationResult();
        }

        #region Props

        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime CreationDate { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Must be implemented to tell if the entity is valid or not
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();

        /// <summary>
        /// Return entity invalid datas 
        /// </summary>
        /// <returns>Collection Validation Failure (errors)</returns>
        public ICollection<ValidationFailure> GetInvalidDataError()
        {
            return ValidationResult.Errors;
        }

        /// <summary>
        /// Change the entity to active
        /// </summary>
        public virtual void Active()
        {
            IsActive = true;
        }

        /// <summary>
        /// Change the entity to deactivate
        /// </summary>
        public virtual void Deactivate()
        {
            IsActive = false;
        }

        #endregion

    }
}
