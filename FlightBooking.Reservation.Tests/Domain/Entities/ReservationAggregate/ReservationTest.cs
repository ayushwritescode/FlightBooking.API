using FlightBooking.Reservation.Domain.ValueObjects;
using Xunit;

namespace FlightBooking.Reservation.Tests.Domain.Entities.ReservationAggregate
{
    public class ReservationTest
    {

        [Fact]
        public void CandAddReservationOk()
        {

            var problems = FlightBooking.Reservation.Domain.Entities.Reservation.CanCreateReservation(GetReservationData());

            Assert.Empty(problems);
        }

        [Fact]
        public void ReservationEmailInvalid()
        {
            var reservationData = GetReservationData();
            reservationData.Email = null;
            var problems = FlightBooking.Reservation.Domain.Entities.Reservation.CanCreateReservation(reservationData);

            Assert.NotEmpty(problems);
        }

        [Fact]
        public void ReservationCreditCardInvalid()
        {

            var reservationData = GetReservationData();
            reservationData.CreditCard = null;
            var problems = FlightBooking.Reservation.Domain.Entities.Reservation.CanCreateReservation(reservationData);

            Assert.NotEmpty(problems);
        }

        private ReservationData GetReservationData()
        {
            return new ReservationData
            {
                Email = "customer@gmail.com",
                CreditCard = "123456789"
            };

        }
    }
}