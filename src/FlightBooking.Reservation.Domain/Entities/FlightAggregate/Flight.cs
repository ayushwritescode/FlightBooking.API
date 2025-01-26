using System;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.Reservation.Domain.Constants;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Resposabilities.Passengers;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Entities
{
    public class Flight : IAggregateRoot
    {
        public DateTime Time { get; set; }

        public string Key { get; set; }
        
        public string Origin { get; set; }
        
        public string Destination { get; set; }

        public decimal Price { get; set; }

        private readonly List<Passenger> _passengers = new List<Passenger>();

        public IReadOnlyCollection<Passenger> Passengers => _passengers.AsReadOnly();

        private IRulesValidation _validation;

        private void ConfigValidation(PassengerData passengerData)
        {
            var fields = new ValidatePassengersFields(passengerData);
            var numberSeat = new ValidateNumericSeat(passengerData);
            var seatRange = new ValidateSeatRange(passengerData);
            var seatFree = new ValidateSeatIsFree(passengerData, _passengers);
            var hasBagSpace = new ValidateBagSpace(passengerData, _passengers);

            fields.Next = numberSeat;
            numberSeat.Next = seatRange;
            seatRange.Next = seatFree;
            seatFree.Next = hasBagSpace;
            hasBagSpace.Next = null;

            _validation = fields;
        }


        /// <summary>
        /// Adds a passenger to the flight.
        /// </summary>
        /// <param name="passengerData">The passenger's data.</param>
        /// <returns>The new passenger instance added to the list.</returns>
        public Passenger AddPassenger(PassengerData passengerData)
        {
            var errors = CanAddPassenger(passengerData);

            var passenger = new Passenger(passengerData.Name, passengerData.Bags, passengerData.Seat, this);

            this._passengers.Add(passenger);

            return passenger;
        }

        /// <summary>
        /// Check if passenger data is valid.
        /// </summary>
        /// <param name="passengerData">An <see cref="Passenger"/> object to validate.</param>
        /// <returns>An <see cref="IEnumerable{DomainValidationMessage}"/> containing the found errors.</returns>
        public IEnumerable<DomainValidationMessage> CanAddPassenger(PassengerData passengerData)
        {
            var errors = new List<DomainValidationMessage>();

            this.ConfigValidation(passengerData);
            this._validation.Validate(errors);
            return errors;
        }

        /// <summary>
        /// Check if a seat number is available.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public bool IsSeatFree(string seat)
        {
            return this._passengers.Select(p => p.Seat).Any(s => s == seat);
        }

        /// <summary>
        /// Check if flight has room for a number of bags.
        /// </summary>
        /// <param name="quantity">The number of bags space needed.</param>
        /// <returns>True if there is the required space, otherwise false.</returns>
        public bool HasBaggageSpace(int quantity)
        {
            return this.Passengers.Sum(c => c.Bags) <= (FlightBookingConstants.MAX_BAGS - quantity);
        }
    }
}
