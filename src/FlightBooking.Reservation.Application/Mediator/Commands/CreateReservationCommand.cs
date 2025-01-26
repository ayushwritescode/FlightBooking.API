using System;
using MediatR;
using FlightBooking.Reservation.Application.Contracts;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Application.Mediator.Commands
{
    public class CreateReservationCommand : ReservationData, IRequest<ReservationConfirmationResponse>
    {
    }
}
