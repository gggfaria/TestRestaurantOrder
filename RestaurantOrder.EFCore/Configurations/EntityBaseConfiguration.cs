using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantOrder.Domain.Entities;
using System;

namespace RestaurantOrder.EFCore.Configurations
{
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
         where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureBaseFields(builder);
            ConfigureTableName(builder);
            ConfigurePK(builder);
            ConfigureFields(builder);
            ConfigureRelation(builder);
        }

        public abstract void ConfigureTableName(EntityTypeBuilder<TEntity> builder);

        public virtual void ConfigurePK(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);
        }

        public abstract void ConfigureFields(EntityTypeBuilder<TEntity> builder);

        public abstract void ConfigureRelation(EntityTypeBuilder<TEntity> builder);

        public void ConfigureBaseFields(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.CreationDate)
                .HasDefaultValue(DateTime.UtcNow);

            builder.HasIndex(p => p.IsActive)
               .IsUnique(false);

            builder.Property(p => p.IsActive)
                .IsRequired();
        }


    }
}
