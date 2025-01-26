using FlightBooking.Reservation.Application.DTO;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Application.Contracts
{
    [Serializable]
    public class ReservationResponse
    {
        [XmlElement]
        public string Email { get; set; }

        [XmlElement]
        public string ReservationNumber { get; set; }

        [XmlElement]
        public List<ReservationFlightDto> Flights { get; set; }
    }
}
