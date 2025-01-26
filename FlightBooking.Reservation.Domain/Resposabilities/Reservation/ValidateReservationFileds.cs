using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Resposabilities.Reservation
{
    public class ValidateReservationFileds : IRulesValidation
    {
        protected readonly ReservationData _command;

        public ValidateReservationFileds(ReservationData command)
        {
            _command = command;
        }

        public IRulesValidation Next { get; set; }

        /// <summary>
        /// Check if booking fields are valid
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {
            if (string.IsNullOrEmpty(this._command.Email))
            {
                messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = Language.EmailNullEmpty, Property = nameof(this._command.Email) });
            }

            if (string.IsNullOrEmpty(this._command.CreditCard))
            {
                messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = Language.CreditCardNullEmprty, Property = nameof(this._command.CreditCard) });
            }

            if (this.Next != null)
            {
                this.Next.Validate(messages);
            }
        }
    }
}
