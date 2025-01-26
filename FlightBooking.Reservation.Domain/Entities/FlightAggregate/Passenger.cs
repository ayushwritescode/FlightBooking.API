namespace FlightBooking.Reservation.Domain.Entities
{
    public sealed class Passenger
    {
        internal Passenger(string name, int bags, string seat, Flight flight)
        {
            this.Name = name;
            this.Bags = bags;
            this.Seat = seat;
            this.Flight = flight;
        }

        public string Name { get; private set; }

        public int Bags { get; private set; }

        public string Seat { get; private set; }

        public Flight Flight { get; private set; }

        public Reservation Reservation { get; internal set; }
    }
}
