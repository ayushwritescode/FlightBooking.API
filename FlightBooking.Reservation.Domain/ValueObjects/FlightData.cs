using System;
using System.Collections.Generic;

namespace FlightBooking.Reservation.Domain.ValueObjects
{
    public class FlightData
    {
        public string Key { get; set; }

        public List<PassengerData> Passengers { get; set; }
    }
}
