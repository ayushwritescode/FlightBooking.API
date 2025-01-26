using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Constants;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Resposabilities.Passengers
{
    public class ValidatePassengersFields : IRulesValidation
    {
        protected readonly PassengerData _command;
        public IRulesValidation Next { get; set; }

        public ValidatePassengersFields(PassengerData command)
        {
            _command = command;
        }

        /// <summary>
        /// Check if Passenger information is valid
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {
            if (string.IsNullOrEmpty(_command.Name))
            {
                messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = Language.PassengerNameMandatory, Property = nameof(_command.Name) });
            }

            if (string.IsNullOrEmpty(_command.Seat))
            {
                messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = Language.SeatNumberMandatory, Property = nameof(_command.Seat) });
            }

            if (_command.Bags > FlightBookingConstants.MAX_BAGS_PASSENGER)
            {
                messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = string.Format(Language.MaxBagsPerUser, _command.Name), Property = nameof(_command.Bags) });
            }

            if (this.Next != null)
            {
                this.Next.Validate(messages);
            }
        }
    }
}
