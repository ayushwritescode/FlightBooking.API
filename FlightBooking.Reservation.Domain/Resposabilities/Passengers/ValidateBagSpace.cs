using System;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.Reservation.Domain.Constants;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Resposabilities.Passengers
{
    public class ValidateBagSpace : IRulesValidation
    {
        protected readonly PassengerData _command;
        protected readonly List<Entities.Passenger> _passengers;

        public IRulesValidation Next { get; set; }

        public ValidateBagSpace(PassengerData command, List<Entities.Passenger> passengers)
        {
            _command = command;
            _passengers = passengers;
        }

        /// <summary>
        /// Check if seats informed in request are in the range (1-50)
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {

            if ( (this._passengers.Sum(c => c.Bags) + _command.Bags ) > FlightBookingConstants.MAX_BAGS)
            {
                messages.Add(new DomainValidationMessage
                {
                    Level = ValidationLevel.Error,
                    Message = string.Format(Resources.Language.SeatInUse, _command.Seat, null),
                    Property = nameof(_command.Seat)
                });
            }


            //go to the next validation
            if (this.Next != null)
                this.Next.Validate(messages);
        }
    }
}
