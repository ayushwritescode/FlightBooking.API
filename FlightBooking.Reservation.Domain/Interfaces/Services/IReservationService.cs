using System;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Interfaces.Services
{
    public interface IReservationService
    {
        Entities.Reservation ConfirmReservation(ReservationData reservationData);
    }
}
