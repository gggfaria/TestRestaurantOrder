using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestaurantOrder.Domain.Repositories.Orders;
using RestaurantOrder.Domain.Utils;
using RestaurantOrder.EFCore.Contexts;
using RestaurantOrder.EFCore.Repositories.Orders;
using RestaurantOrder.Service.ConcreteServices;
using RestaurantOrder.Service.MapConfigs;
using RestaurantOrder.Service.ServicesInterfaces;
using System;
using System.IO;

namespace RestaurantOrder.WebApi
{
    public class StartupTests
    {
        public StartupTests(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigDataBase(services);
            ConfiAutoMapper(services);
            ConfigServices(services);
            ConfigRepositories(services);
            ConfigSwagger(services);

            services.AddControllers();
        }

        private void ConfigDataBase(IServiceCollection services)
        {
            var appSettings = Configuration.Get<AppSettings>();

            services.AddDbContext<RestaurantOrderContext>(opt =>
            {
                opt.UseSqlServer(appSettings.ConnectionStrings.SQLServerConnection);
            }, ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.). Specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Order API Test");
            });
        }

        private void ConfiAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(OrderDTOConfig),
                typeof(AreaDTOConfig),
                typeof(ResponseDTOConfig)
            );
        }

        private void ConfigServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAreaService, AreaService>();
        }

        private void ConfigRepositories(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAreaRepository, AreaRepository>();
        }

        private void ConfigSwagger(IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Restaurant Order API",
                        Version = "v1",
                        Description = "Teste para desenvolvedor de software",
                        Contact = new OpenApiContact
                        {
                            Name = "Teste",
                            Url = new Uri("http://teste.com/api")
                        }
                    });
            });

        }
    }
}
