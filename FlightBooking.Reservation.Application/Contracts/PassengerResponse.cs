using System;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Application.Contracts
{
    [Serializable]
    public class PassengerResponse
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public int Bags { get; set; }

        [XmlElement]
        public string Seat { get; set; }
    }
}
