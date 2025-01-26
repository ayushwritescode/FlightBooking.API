using System;
using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Resposabilities.Passengers
{
    public class ValidateNumericSeat : IRulesValidation
    {
        protected readonly PassengerData _command;
        public IRulesValidation Next { get; set; }

        public ValidateNumericSeat(PassengerData command)
        {
            _command = command;
        }

        /// <summary>
        /// Check if value in request is a numeric value
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {
            if (!int.TryParse(_command.Seat, out int n))
            {
                messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = string.Format(Language.SeatNumberError, _command.Seat), Property = nameof(_command.Seat) });
            }

            if (this.Next != null)
                this.Next.Validate(messages);
        }
    }
}
