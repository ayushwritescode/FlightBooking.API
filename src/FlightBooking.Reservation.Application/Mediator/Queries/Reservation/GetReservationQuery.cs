using System;
using MediatR;
using FlightBooking.Reservation.Application.Contracts;

namespace FlightBooking.Reservation.Application.Mediator.Queries.Reservation
{
    public class GetReservationQuery : IRequest<ReservationResponse>
    {
        public string ReservationNumber { get; set; }
    }
}
