using System;
using System.Threading;
using AutoMapper;
using FlightBooking.Reservation.Application.Mediator.Queries.Flight;
using FlightBooking.Reservation.Application.Profiles;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Infrastructure.Repositories;
using Xunit;

namespace FlightBooking.Reservation.Tests.Application.Mediator.Queries.Flight
{
    public class GetFlightsByParamQueryHandlerTest
    {
        [Fact]
        public void GetFlightInformationOk()
        {
            IRepository<FlightBooking.Reservation.Domain.Entities.Flight> flightRepository = new FlightRepository();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FlightBookingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var token = new CancellationToken();

            var handler = new GetFlightsByParamQueryHandler(flightRepository, mapper);

            var result = handler.Handle(GetQuery(), token).Result;
            var expected = 3;
            Assert.Equal(expected, result.Count);
        }

        [Fact]
        public void NoFlightInformation()
        {
            IRepository<FlightBooking.Reservation.Domain.Entities.Flight> flightRepository = new FlightRepository();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FlightBookingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var token = new CancellationToken();

            var handler = new GetFlightsByParamQueryHandler(flightRepository, mapper);

            var query = GetQuery();
            query.Destination = "SAO PAULO";
            var expected = 0;
            var result = handler.Handle(query, token).Result;

            Assert.Equal(result.Count, expected);
        }

        private GetFlightsByParamQuery GetQuery()
        {
            return new GetFlightsByParamQuery
            {
                Passengers = 3,
                Origin = "DUBLIN",
                Destination = "LONDON",
                DateOut = new DateTime(2021, 5, 8).Date,
                DateIn = new DateTime(2021, 5, 10).Date,
                RoundTrip = true
            };
        }

    }
}
