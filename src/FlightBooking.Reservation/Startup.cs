using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using FlightBooking.Reservation.Application.Mediator;
using FlightBooking.Reservation.Application.Profiles;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Interfaces.Services;
using FlightBooking.Reservation.Domain.Services;
using FlightBooking.Reservation.Infrastructure.Repositories;
using FlightBooking.Reservation.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace FlightBooking.Reservation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.EnableEndpointRouting = false;
            }).AddXmlSerializerFormatters();

            services.AddScoped<IMediator, Mediator>();
            services.AddMediatorHandlers();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FlightBookingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Adding repositories as singleton because we are using in memory collections.
            services.AddSingleton<IRepository<Domain.Entities.Flight>, FlightRepository>();
            services.AddSingleton<IRepository<Domain.Entities.Reservation>, ReservationRepository>();
            services.AddSingleton<IRepository<Domain.Entities.Promotion>, PromotionRepository>();

            // Domain services.
            services.AddSingleton<IReservationService, ReservationService>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightBooking Reservation", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseUnhandledExceptionMiddleware();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationAPI");
            });

            app.UseMvc();
        }
    }
}
