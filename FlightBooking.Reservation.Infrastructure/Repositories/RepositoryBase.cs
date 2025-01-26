using System;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.Reservation.Domain.Interfaces;

namespace FlightBooking.Reservation.Infrastructure.Repositories
{
    /// <summary>
    /// Repository base class to Delete, Insert and List data
    /// </summary>
    /// <typeparam name="T">Type of data on repository</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : IAggregateRoot
    {
        protected List<T> collection = new List<T>();

        public void Delete(T entity) => collection.Remove(entity);

        public void Insert(T entity) => collection.Add(entity);

        public IEnumerable<T> List() => collection;

        public IEnumerable<T> List(ISpecification<T> specification) => collection.AsQueryable().Where(specification.ToExpression());
    }
}
