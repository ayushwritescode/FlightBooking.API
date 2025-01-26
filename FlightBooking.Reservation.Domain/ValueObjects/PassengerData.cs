using System;
namespace FlightBooking.Reservation.Domain.ValueObjects
{
    /// <summary>
    /// Used to carry passenger data to book the flight.
    /// </summary>
    public class PassengerData
    {
        public string Name { get; set; }
        public int Bags { get; set; }
        public string Seat { get; set; }
    }
}
