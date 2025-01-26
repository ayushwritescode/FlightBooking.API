using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using FlightBooking.Reservation.Application.Contracts;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Interfaces.Services;

namespace FlightBooking.Reservation.Application.Mediator.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ReservationConfirmationResponse>
    {
        private readonly IReservationService _reservationService;
        private readonly IRepository<Domain.Entities.Reservation> _reservationRepository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(
            IReservationService reservationService,
            IRepository<Domain.Entities.Reservation> reservationRepository,
            IMapper mapper)
        {
            _reservationService = reservationService;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public Task<ReservationConfirmationResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _reservationService.ConfirmReservation(request);

            _reservationRepository.Insert(reservation);

            var converted = _mapper.Map<ReservationConfirmationResponse>(reservation);

            // We heve nothing to await, so let's just return a Task object.
            return Task.FromResult(converted);
        }

    }
}
