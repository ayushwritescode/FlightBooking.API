using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using FlightBooking.Reservation.Application.Mediator.Commands;
using FlightBooking.Reservation.Application.Profiles;
using FlightBooking.Reservation.Domain.Entities;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Interfaces.Services;
using FlightBooking.Reservation.Domain.Services;
using FlightBooking.Reservation.Domain.Validation;
using FlightBooking.Reservation.Domain.ValueObjects;
using FlightBooking.Reservation.Infrastructure.Repositories;
using Xunit;

namespace FlightBooking.Reservation.Tests.Application.Mediator.Commands
{
    public class CreateReservationCommandHandlerTest
    {
        [Fact]
        public void CreateReservationCommandOk()
        {
            IRepository<FlightBooking.Reservation.Domain.Entities.Reservation> reservationRepository = new ReservationRepository();
            IRepository<Flight> flightRepository = new FlightRepository();
            IReservationService service = new ReservationService(flightRepository);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FlightBookingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var token = new CancellationToken();

            var handler = new CreateReservationCommandHandler(service, reservationRepository, mapper);

            var result  = handler.Handle(GetReservationData(),token).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateReservationCommandFail()
        {
            IRepository<FlightBooking.Reservation.Domain.Entities.Reservation> reservationRepository = new ReservationRepository();
            IRepository<Flight> flightRepository = new FlightRepository();
            IReservationService service = new ReservationService(flightRepository);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FlightBookingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var token = new CancellationToken();

            var handler = new CreateReservationCommandHandler(service, reservationRepository, mapper);
            var command = GetReservationData();
            command.Email = null;

            Assert.Throws<DomainValidationException>(() => handler.Handle(command, token).Result);
        }

        private CreateReservationCommand GetReservationData()
        {
            return new CreateReservationCommand
            {
                Email = "customer@gmail.com",
                CreditCard = "123456789",
                Flights = new List<FlightData>()
                {
                    new FlightData
                    {
                        Key = "Flight00052",
                        Passengers = new List<PassengerData>()
                        {
                            new PassengerData
                            {
                                Bags = 2,
                                Name = "Customer A",
                                Seat = "02"
                            },
                            new PassengerData
                            {
                                Bags = 2,
                                Name = "Customer B",
                                Seat = "03"
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
                                Bags = 2,
                                Name = "Customer C",
                                Seat = "10"
                            },
                            new PassengerData
                            {
                                Bags = 2,
                                Name = "Customer D",
                                Seat = "11"
                            }
                        }
                    }
                }

            };

        }

    }
}
