using System;
using System.Linq.Expressions;

namespace FlightBooking.Reservation.Domain.Specifications.Flight
{
    public class FlightFlyingToSpec : SpecificationBase<Entities.Flight>
    {
        private readonly Expression<Func<Entities.Flight, bool>> _expression;
        public FlightFlyingToSpec(string destination)
        {
            _expression = flightFlyingTo => flightFlyingTo.Destination.ToLowerInvariant() == destination.ToLowerInvariant();
        }

        public override Expression<Func<Entities.Flight, bool>> ToExpression()
        {
            return _expression;
        }
    }
}
