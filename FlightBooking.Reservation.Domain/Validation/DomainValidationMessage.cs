using System;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Domain.Validation
{
    public class DomainValidationMessage
    {
        [XmlElement]
        public ValidationLevel Level { get; set; }
        [XmlElement]
        public string Property { get; set; }
        [XmlElement]
        public string Message { get; set; }
    }
}
