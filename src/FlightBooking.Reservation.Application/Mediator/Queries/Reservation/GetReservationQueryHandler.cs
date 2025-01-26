using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using FlightBooking.Reservation.Application.Contracts;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Specifications.Reservation;

namespace FlightBooking.Reservation.Application.Mediator.Queries.Reservation
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, ReservationResponse>
    {
        private readonly IRepository<Domain.Entities.Reservation> _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationQueryHandler(IRepository<Domain.Entities.Reservation> reservationRepository,
            IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public Task<ReservationResponse> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = _reservationRepository.List(new ReservationByNumberSpec(request.ReservationNumber)).FirstOrDefault();

            var converted = _mapper.Map<ReservationResponse>(reservation);

            return Task.FromResult(converted);
        }
    }
}
