using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBooking.Reservation.Domain.Resposabilities.Flight
{
    public class ValidatePromoCode : IRulesValidation
    {
        protected readonly string _promoCode;
        public IRulesValidation Next { get; set; }

        public ValidatePromoCode(string promoCode)
        {
            _promoCode = promoCode;
        }

        /// <summary>
        /// Check if Promotion code is valid
        /// </summary>
        /// <param name="messages">Messages.</param>
        public void Validate(List<DomainValidationMessage> messages)
        {
            //Code to validate promo code here

            if (this.Next != null)
            {
                this.Next.Validate(messages);
            }
        }
    }
}
