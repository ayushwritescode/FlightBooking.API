using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using FlightBooking.Reservation.Domain.Validation;

namespace FlightBooking.Reservation.Application.Contracts
{
    [Serializable]
    public class DomainValidationExceptionResponse : ExceptionResponse
    {
        [XmlElement]
        public List<DomainValidationMessage> ValidationMessages { get; set; }
    }
}
