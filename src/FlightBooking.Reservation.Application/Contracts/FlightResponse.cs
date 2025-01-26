using System;
using System.Xml.Serialization;

namespace FlightBooking.Reservation.Application.Contracts
{
    [Serializable]
    public class FlightResponse
    {
        [XmlElement]
        public string Destination { get; set; }

        [XmlElement]
        public string Key { get; set; }
        
        [XmlElement]
        public string Origin { get; set; }
        
        [XmlElement(DataType = "date")]
        public DateTime Time { get; set; }

        [XmlElement]
        public Decimal Price { get; set; }
    }
}
