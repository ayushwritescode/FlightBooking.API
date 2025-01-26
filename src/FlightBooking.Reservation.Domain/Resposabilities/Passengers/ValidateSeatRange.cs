using System;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.Reservation.Domain.Constants;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Resposabilities.Passengers
{
    public class ValidateSeatRange : IRulesValidation
    {
        protected readonly PassengerData _command;

        public IRulesValidation Next { get; set; }

        public ValidateSeatRange(PassengerData command)
        {
            _command = command;
        }

        /// <summary>
        /// Check if seats informed in request are in the range (1-50)
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {
            int.TryParse(_command.Seat, out int seatNumber);

            if (!Enumerable.Range(FlightBookingConstants.INITIAL_SEAT, FlightBookingConstants.FINAL_SEAT).ToList().Contains(seatNumber))
            {
               messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = string.Format(Language.SeatNumberRange, _command.Seat), Property = nameof(_command.Seat) });
            }

            //go to the next validation
            if (this.Next != null)
                this.Next.Validate(messages);
        }
    }
}
