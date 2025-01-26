using System;
using System.Collections.Generic;

namespace FlightBooking.Reservation.Domain.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IEnumerable<T> List();
        
        IEnumerable<T> List(ISpecification<T> specification);

        void Insert(T entity);

        void Delete(T entity);
    }
}
