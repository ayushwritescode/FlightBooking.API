using System;
using System.Collections.Generic;
using FlightBooking.Reservation.Domain.Entities;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Interfaces.Services;
using FlightBooking.Reservation.Domain.Services;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;
using FlightBooking.Reservation.Infrastructure.Repositories;
using Xunit;

namespace FlightBooking.Reservation.Tests.Domain.Services
{
    public class ReservationServiceTest
    {
        [Fact]
        public void CreatingReservationOk()
        {
            IRepository<Flight> _flightRepository = new FlightRepository();
            IReservationService service = new ReservationService(_flightRepository);
            var result = service.ConfirmReservation(GetEntityValidEntity());
            Assert.NotNull(result);
        }

        [Fact]
        public void CreatingReservationNoFlightKeyInformationError()
        {
            IRepository<Flight> _flightRepository = new FlightRepository();
            IReservationService service = new ReservationService(_flightRepository);

            var data = GetEntityValidEntity();
            data.Flights[0].Key = "";

            Assert.Throws<DomainValidationException>(() => service.ConfirmReservation(data));
        }

        [Fact]
        public void CreatingReservationNoFlightInformationError()
        {
            IRepository<Flight> _flightRepository = new FlightRepository();
            IReservationService service = new ReservationService(_flightRepository);

            var data = GetEntityValidEntity();
            data.Flights = null;

            Assert.Throws<DomainValidationException>(() => service.ConfirmReservation(data));
        }

        //Test incompleted and used to validate if promo codes have invalid formats
        [Fact]
        public void CreatingReservationPromoCodeWrongFormat()
        {
            IRepository<Flight> _flightRepository = new FlightRepository();
            IReservationService service = new ReservationService(_flightRepository);

            var data = GetEntityValidEntity();
            Assert.True(false);
        }

        private ReservationData GetEntityValidEntity()
        {
            return new ReservationData()
            {
                Email = "contact@contact.com",
                CreditCard = "0123456789012345",
                Flights = new List<FlightData>()
                {
                    new FlightData
                    {
                        Key = "Flight00052",
                        Passengers = new List<PassengerData>()
                        {
                            new PassengerData
                            {
                                Name = "Robert Plant",
                                Bags = 2,
                                Seat = "27"
                            },
                            new PassengerData
                            {
                                Name = "Ozzy Osbourne",
                                Bags = 0,
                                Seat = "28"
                            }
                        }
                    },
                    new FlightData
                    {
                        Key = "Flight00103",
                        Passengers = new List<PassengerData>()
                        {
                            new PassengerData
                            {
                                Name = "Robert Plant",
                                Bags = 2,
                                Seat = "41"
                            },
                            new PassengerData
                            {
                                Name = "Ozzy Osbourne",
                                Seat = "40"
                            }
                        }
                    }
                },
                PromoCode = "PROMO40OFF"
            };
        }
    }
}
