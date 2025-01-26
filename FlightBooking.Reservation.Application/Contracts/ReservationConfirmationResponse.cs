using System;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Application.Contracts
{
    [Serializable]
    public class ReservationConfirmationResponse
    {
        [XmlElement]
        public string ReservationNumber { get; set; }
    }
}
