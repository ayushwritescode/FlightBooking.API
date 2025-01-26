using System;
using AutoMapper;
using FlightBooking.Reservation.Application.Contracts;
using FlightBooking.Reservation.Application.DTO;
using FlightBooking.Reservation.Domain.Entities;
using FlightBooking.Reservation.Domain.Validation;

namespace FlightBooking.Reservation.Application.Profiles
{
    public class FlightBookingProfile : Profile
    {
        public FlightBookingProfile()
        {
            CreateMap<Flight, FlightResponse>().ReverseMap();
            CreateMap<Domain.Entities.Reservation, ReservationConfirmationResponse>().ReverseMap();
            CreateMap<Domain.Entities.Reservation, ReservationResponse>().ReverseMap();
            CreateMap<Domain.Entities.ReservationFlight, ReservationFlightDto>().ReverseMap();
            CreateMap<Domain.Entities.Passenger, PassengerResponse>().ReverseMap();

            CreateMap<DomainValidationException, DomainValidationExceptionResponse>().ReverseMap();
            CreateMap<System.Exception, ExceptionResponse>().ReverseMap();

        }
    }
}
