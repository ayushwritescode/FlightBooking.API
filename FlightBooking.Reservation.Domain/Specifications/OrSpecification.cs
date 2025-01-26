using System;
using System.Linq;
using System.Linq.Expressions;
using FlightBooking.Reservation.Domain.Interfaces;

namespace FlightBooking.Reservation.Domain.Specifications
{
    /// <summary>
    /// Combines two specifications using || (OR) operator.
    /// </summary>
    /// <typeparam name="T">An implementation of <see cref="IAggregateRoot"/>.</typeparam>
    public class OrSpecification<T> : SpecificationBase<T> where T : IAggregateRoot
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();


            var invokedExpr = Expression.Invoke(rightExpression, leftExpression.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(leftExpression.Body, invokedExpr), leftExpression.Parameters);
        }

    }
}
