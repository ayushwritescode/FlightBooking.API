using System.Collections.Generic;

namespace FlightBooking.Reservation.Domain.Entities
{
    public sealed class ReservationFlight
    {
        public ReservationFlight(Flight flight, IEnumerable<Passenger> passengers)
        {
            this.Flight = flight;
            this.Key = flight.Key;
            this._passengers.AddRange(passengers);
        }

        public Flight Flight { get; private set; }

        public string Key { get; private set; }

        // Using IReadOnlyCollection as a wrapper around a private list,
        // the only way to add passenger is through AddPassenger method, so is protected against "external updates".
        private readonly List<Passenger> _passengers = new List<Passenger>();
        
        public IReadOnlyCollection<Passenger> Passengers => _passengers.AsReadOnly();
    }
}
