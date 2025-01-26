using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Resposabilities.Flight;
using FlightBooking.Reservation.Domain.Validation;

namespace FlightBooking.Reservation.Domain.Entities
{
    public class Promotion : IAggregateRoot
    {
        public string FlightKey { get; set; }

        public string PromoCode { get; set; }

        private readonly List<Promotion> _promotion = new List<Promotion>();

        public IReadOnlyCollection<Promotion> Promotions => _promotion.AsReadOnly();

        private IRulesValidation _validation;

        private void PromotionValidation(string promoCode)
        {
            var promotion = new ValidatePromoCode(promoCode);

            promotion.Next = null;

            _validation = promotion;
        }

        public IEnumerable<DomainValidationMessage> ValidatePromoCodeFormat(string promoCode)
        {
            var errors = new List<DomainValidationMessage>();

            this.PromotionValidation(promoCode);
            this._validation.Validate(errors);
            return errors;
        }
    }
}
