using System;
using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Resposabilities.Flight
{

    public class ValidateFlightKey : IRulesValidation
    {
        protected readonly ReservationData _command;

        public IRulesValidation Next { get; set; }

        public ValidateFlightKey(ReservationData command)
        {
            _command = command;
        }

        /// <summary>
        /// Check if flight information is consistent
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {

            foreach (var item in _command?.Flights)
            {
                if (string.IsNullOrEmpty(item.Key))
                {
                    messages.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = string.Format(Language.FlightNullEmpty, item.Key), Property = nameof(item.Key) });
                }
            }

            //go to next validation
            if (this.Next != null)
            {
                this.Next.Validate(messages);
            }
        }
    }


}
