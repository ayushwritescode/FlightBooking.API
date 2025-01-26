using System;
using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Validation;

namespace FlightBooking.Reservation.Domain.Interfaces
{
    public interface IRulesValidation
    {
        void Validate(List<DomainValidationMessage> messages);
        IRulesValidation Next { get; set; }
    }
}
