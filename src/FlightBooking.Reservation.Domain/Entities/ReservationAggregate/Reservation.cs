using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Utils;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Entities
{
    public sealed class Reservation : IAggregateRoot
    {
        private Reservation() { }
        private Reservation(string email, string creditCard)
        {
            this.Email = email;
            this.CreditCard = creditCard;
            this.ReservationNumber = this.RandomReservationNumber();
        }

        public string CreditCard { get; set; }
        
        public string ReservationNumber { get; set; }
        
        public string Email { get; set; }

        // Using IReadOnlyCollection as a wrapper around a private list, so is protected against "external updates".
        private readonly List<ReservationFlight> _flights = new List<ReservationFlight>();
        
        public IReadOnlyCollection<ReservationFlight> Flights => _flights.AsReadOnly();

        public static Reservation CreateReservation(ReservationData reservationData)
        {
            var problems = CanCreateReservation(reservationData);

            if (problems.Any())
            {
                throw new DomainValidationException(problems);
            }

            return new Reservation(reservationData.Email, reservationData.CreditCard);
        }


        public static IEnumerable<DomainValidationMessage> CanCreateReservation(ReservationData reservationData)
        {
            var errors = new List<DomainValidationMessage>();

            if (string.IsNullOrEmpty(reservationData.Email))
            {
                errors.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = Resources.Language.EmailNullEmpty, Property = nameof(reservationData.Email) });
            }

            if (string.IsNullOrEmpty(reservationData.CreditCard))
            {
                errors.Add(new DomainValidationMessage { Level = ValidationLevel.Error, Message = Resources.Language.CreditCardNullEmprty, Property = nameof(reservationData.CreditCard) });
            }

            return errors;
        }


        public void AddFlight(Flight flight, IEnumerable<Passenger> passengers)
        {
            this._flights.Add(new ReservationFlight(flight, passengers));
        }

        /// <summary>
        /// Generates and return a random number for reservation.
        /// </summary>
        /// <returns>A random string in the format GHT002</returns>
        private string RandomReservationNumber()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomGenerator.RandomString(3, false));
            builder.Append(RandomGenerator.RandomNumber(100, 999));

            return builder.ToString();
        }
    }
}
