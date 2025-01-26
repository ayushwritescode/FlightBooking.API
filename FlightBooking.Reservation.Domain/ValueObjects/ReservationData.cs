using System;
using System.Collections.Generic;

namespace FlightBooking.Reservation.Domain.ValueObjects
{
    public class ReservationData
    {
        public string Email { get; set; }
        public string CreditCard { get; set; }
        public List<FlightData> Flights { get; set; }
        public string PromoCode { get; set; }
    }
}
