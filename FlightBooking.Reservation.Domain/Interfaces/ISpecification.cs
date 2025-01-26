using System;
using System.Linq.Expressions;

namespace FlightBooking.Reservation.Domain.Interfaces
{
    /// <summary>
    /// One Domain-Driven-Design solution to the problem of where to place querying, sorting, and paging logic is to use a Specification.
    /// It helps to avoid spreading queries to application layer, or repositories become bloated with many custom query methods.
    /// https://deviq.com/specification-pattern/
    /// </summary>
    /// <typeparam name="T">An <see cref="IAggregateRoot"/> implementation.</typeparam>
    public interface ISpecification<T> where T : IAggregateRoot
    {
        /// <summary>
        /// Builds the expression to filter the entities.
        /// </summary>
        /// <returns>An <see cref="Expression{Func{T, bool}}"/> object to filter entities.</returns>
        Expression<Func<T, bool>> ToExpression();

        /// <summary>
        /// Combines two specificaitons using the &&(And) operator.
        /// </summary>
        /// <param name="specification">The specification to combine with.</param>
        /// <returns>A new combined <see cref="ISpecification{T}"/>.</returns>
        ISpecification<T> And(ISpecification<T> specification);

        /// <summary>
        /// Combines two specificaitons using the ||(Or) operator.
        /// </summary>
        /// <param name="specification">The specification to combine with.</param>
        /// <returns>A new combined <see cref="ISpecification{T}"/>.</returns>
        ISpecification<T> Or(ISpecification<T> specification);

    }
}
