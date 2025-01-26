using System;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.Reservation.Domain.Entities;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Interfaces.Services;
using FlightBooking.Reservation.Domain.Resources;
using FlightBooking.Reservation.Domain.Specifications.Flight;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;

namespace FlightBooking.Reservation.Domain.Services
{
    /// <summary>
    /// Service used to make a flight reservation after validating the input data
    /// </summary>
    public sealed class ReservationService : IReservationService
    {
        private readonly IRepository<Flight> _flightRepository;

        public ReservationService(IRepository<Flight> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public Domain.Entities.Reservation ConfirmReservation(ReservationData reservationData)
        {
            var problems = new List<DomainValidationMessage>();

            //Validate if flights are not null
            if ((reservationData?.Flights == null) || (reservationData?.Flights?.Count == 0))
            {
                problems.Add(new DomainValidationMessage
                {
                    Level = ValidationLevel.Error,
                    Message = Language.NoFlightInformation,
                    Property = "Flights"
                });
                throw new DomainValidationException(problems);
            }

            //Validate promoCode format if appliable
            if (!string.IsNullOrEmpty(reservationData.PromoCode))
            {
                Promotion promotion = new Promotion();
                var promoCodeValidation = promotion.ValidatePromoCodeFormat(reservationData.PromoCode);
                if (promoCodeValidation?.Any() == true)
                {
                    problems.AddRange(promoCodeValidation);
                }
            }

            var validatedFlights = new Dictionary<Flight, IEnumerable<PassengerData>>();

            //Validate each flight and each passenger
            foreach (FlightData fData in reservationData.Flights)
            {
                Flight flight = _flightRepository.List(new FlightByKeySpec(fData.Key)).FirstOrDefault();

                if (flight == null)
                {
                    problems.Add(new DomainValidationMessage
                    {
                        Level = ValidationLevel.Error,
                        Message = Language.FlightNotExists,
                        Property = "Flights"
                    });
                    throw new DomainValidationException(problems);
                }

                validatedFlights.Add(flight, fData.Passengers);

                // Validate each passenger.
                foreach (var passenger in fData.Passengers)
                {
                    problems.AddRange(flight.CanAddPassenger(passenger));
                }
            }

            problems.AddRange(Entities.Reservation.CanCreateReservation(reservationData));

            // If there is any problems with data we throw an exception.
            if (problems.Any())
                throw new DomainValidationException(problems);

            var reservation = Entities.Reservation.CreateReservation(reservationData);

            // Now we have sure everything is right lets create the reservation.

            // Now we add the passengers to the flight.
            // Using the dictionary we save some roud trips to repository.
            foreach (KeyValuePair<Flight, IEnumerable<PassengerData>> pair in validatedFlights)
            {
                var flight = pair.Key;
                var passengersAdded = new List<Passenger>();

                foreach (var passengerData in pair.Value)
                {
                    var passenger = flight.AddPassenger(passengerData);
                    passengersAdded.Add(passenger);
                }

                // Add the flight to the resrevation.
                reservation.AddFlight(flight, passengersAdded);
            }

            return reservation;
        }
    }
}
