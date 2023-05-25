using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantOrder.Domain.Entities.Orders;

namespace RestaurantOrder.EFCore.Configurations.Orders
{
    public class AreaConfiguration : EntityBaseConfiguration<Area>
    {
        public override void ConfigureFields(EntityTypeBuilder<Area> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique(true);
        }

        public override void ConfigureRelation(EntityTypeBuilder<Area> builder)
        {
            builder.HasMany(p => p.Orders);
        }

        public override void ConfigureTableName(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Areas");
        }


    }
}
