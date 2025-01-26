using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FlightBooking.Reservation.Application.Contracts;
using FlightBooking.Reservation.Application.Mediator.Commands;
using FlightBooking.Reservation.Application.Mediator.Queries.Flight;
using FlightBooking.Reservation.Application.Mediator.Queries.Reservation;

namespace FlightBooking.Reservation.Application.Mediator
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateReservationCommand, ReservationConfirmationResponse>, CreateReservationCommandHandler>();

            services.AddTransient<IRequestHandler<GetFlightsByParamQuery, List<FlightResponse>>, GetFlightsByParamQueryHandler>();
            services.AddTransient<IRequestHandler<GetReservationQuery, ReservationResponse>, GetReservationQueryHandler>();

            return services;
        }
    }
}
