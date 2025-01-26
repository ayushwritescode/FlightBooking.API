using System;
using System.Linq.Expressions;

namespace FlightBooking.Reservation.Domain.Specifications.Flight
{
    public class FlightDepartsOnSpec : SpecificationBase<Entities.Flight>
    {
        private readonly Expression<Func<Entities.Flight, bool>> _expression;
        public FlightDepartsOnSpec(DateTime date)
        {
            _expression = flightDepartsOn => flightDepartsOn.Time.Date == date.Date;
        }

        public override Expression<Func<Entities.Flight, bool>> ToExpression()
        {
            return _expression;
        }
    }
}
