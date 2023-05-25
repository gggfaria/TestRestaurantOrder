using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantOrder.Domain.Entities.Orders;
using RestaurantOrder.EFCore.Configurations.Orders;

namespace RestaurantOrder.EFCore.Contexts
{
    public class RestaurantOrderContext : DbContext
    {
        public static readonly ILoggerFactory LoggerFactoryEF = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                .AddConsole();
        });

        public RestaurantOrderContext(DbContextOptions<RestaurantOrderContext> options)
        : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactoryEF);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<FluentValidation.Results.ValidationFailure>();
            modelBuilder.Ignore<FluentValidation.Results.ValidationResult>();

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new ItemOrderConfiguration());

        }

    }
}
