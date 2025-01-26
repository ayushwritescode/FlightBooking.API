using System.Xml.Serialization;

namespace FlightBooking.Reservation.Domain.Validation
{
    public enum ValidationLevel
    {
        [XmlEnum(Name = "Info")]
        Info,
        [XmlEnum(Name = "Warning")]
        Warning,
        [XmlEnum(Name = "Error")]
        Error
    }
}
