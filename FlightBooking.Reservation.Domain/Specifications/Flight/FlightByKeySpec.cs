using System;
using System.Linq.Expressions;

namespace FlightBooking.Reservation.Domain.Specifications.Flight
{
    public sealed class FlightByKeySpec : SpecificationBase<Entities.Flight>
    {
        private readonly Expression<Func<Entities.Flight, bool>> _expression;
        public FlightByKeySpec(string key)
        {
            _expression = flightByKey => flightByKey.Key == key;
        }

        public override Expression<Func<Entities.Flight, bool>> ToExpression()
        {
            return _expression;
        }
    }
}
