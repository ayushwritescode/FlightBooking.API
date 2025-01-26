using System;
using System.Linq.Expressions;

namespace FlightBooking.Reservation.Domain.Specifications.Reservation
{
    /// <summary>
    /// Filters reservation by number.
    /// </summary>
    public class ReservationByNumberSpec : SpecificationBase<Entities.Reservation>
    {
        private Expression<Func<Entities.Reservation, bool>> expression;
        public ReservationByNumberSpec(string number)
        {
            expression = reservationByNumber => reservationByNumber.ReservationNumber == number;
        }

        public override Expression<Func<Entities.Reservation, bool>> ToExpression()
        {
            return this.expression;
        }
    }
}
