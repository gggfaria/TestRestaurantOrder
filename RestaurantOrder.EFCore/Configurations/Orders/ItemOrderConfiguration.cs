using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantOrder.Domain.Entities.Orders;

namespace RestaurantOrder.EFCore.Configurations.Orders
{
    public class ItemOrderConfiguration : EntityBaseConfiguration<ItemOrder>
    {
        public override void ConfigureFields(EntityTypeBuilder<ItemOrder> builder)
        {
            builder.Property(p => p.ProductName)
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(p => p.UnitPrice)
                .IsRequired();

            builder.Property(p => p.Amount)
                .IsRequired();
        }

        public override void ConfigureRelation(EntityTypeBuilder<ItemOrder> builder)
        {
            builder.HasOne(p => p.Order)
              .WithMany(p => p.ItemOrder)
              .HasForeignKey(p => p.OrderId);
        }

        public override void ConfigureTableName(EntityTypeBuilder<ItemOrder> builder)
        {
            builder.ToTable("ItemOrders");
        }


    }
}
