using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantOrder.Domain.Entities.Orders;

namespace RestaurantOrder.EFCore.Configurations.Orders
{
    public class OrderConfiguration : EntityBaseConfiguration<Order>
    {
        public override void ConfigureFields(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.TotalPrice)
              .IsRequired();
        }

        public override void ConfigureRelation(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(p => p.Area)
              .WithMany(p => p.Orders)
              .HasForeignKey(p => p.AreaId);

            builder.HasMany(p => p.ItemOrder);
        }

        public override void ConfigureTableName(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
        }
    }
}
