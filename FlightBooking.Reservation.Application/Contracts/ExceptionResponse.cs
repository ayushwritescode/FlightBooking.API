using System;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Application.Contracts
{
    [Serializable]
    public class ExceptionResponse
    {
        [XmlElement]
        public string Message { get; set; }

        [XmlElement]
        public string StackTrace { get; set; }
    }
}
