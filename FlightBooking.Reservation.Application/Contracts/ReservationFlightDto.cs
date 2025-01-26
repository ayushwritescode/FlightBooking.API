using FlightBooking.Reservation.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Application.DTO
{
    [Serializable]
    public class ReservationFlightDto
    {
        [XmlElement]
        public string Key { get; set; }

        [XmlElement]
        public List<PassengerResponse> Passengers { get; set; }
    }
}
