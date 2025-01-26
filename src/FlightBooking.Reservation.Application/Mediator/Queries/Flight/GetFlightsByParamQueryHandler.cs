using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using FlightBooking.Reservation.Application.Contracts;
using FlightBooking.Reservation.Domain.Interfaces;
using FlightBooking.Reservation.Domain.Specifications.Flight;

namespace FlightBooking.Reservation.Application.Mediator.Queries.Flight
{
    public class GetFlightsByParamQueryHandler : IRequestHandler<GetFlightsByParamQuery, List<FlightResponse>>
    {
        private readonly IRepository<Domain.Entities.Flight> _flightRepository;
        private readonly IMapper _mapper;

        public GetFlightsByParamQueryHandler(IRepository<Domain.Entities.Flight> flightRepository,
            IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public Task<List<FlightResponse>> Handle(GetFlightsByParamQuery request, CancellationToken cancellationToken)
        {
            var outboundFlightSpec = new FlightDepartsFromSpec(request.Origin)
                .And(new FlightHasFreeSeatsSpec(request.Passengers))
                .And(new FlightFlyingToSpec(request.Destination))
                .And(new FlightDepartsOnSpec(request.DateOut));
                
            var flightSearch = outboundFlightSpec;

            // If it's a round trip, we combine the spec to filter inbound flight.
            if (request.RoundTrip)
            {
                var inboundFlightSpec = new FlightDepartsFromSpec(request.Destination)
                    .And(new FlightHasFreeSeatsSpec(request.Passengers))
                    .And(new FlightFlyingToSpec(request.Origin))
                    .And(new FlightDepartsOnSpec(request.DateIn.Value));

                flightSearch = flightSearch.Or(inboundFlightSpec);
            }

            var flights = _flightRepository.List(flightSearch);

            var converted = _mapper.Map<List<FlightResponse>>(flights);
            return Task.FromResult(converted.ToList());
        }
    }
}
