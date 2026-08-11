using _10Aug2026.Data;
using _10Aug2026.Models;

namespace _10Aug2026.Services
{
    public class BookingService
    {
        private readonly AppDbContext context;

        public BookingService(AppDbContext context)
        {
            this.context = context;
        }

        public Booking CreateBooking(Booking booking)
        {
            // 1. Check travel date
            if (booking.TravelDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException(
                    "Travel Date cannot be in the past"
                );
            }

            // 2. Check whether bus exists
            var bus = context.Buses
                .FirstOrDefault(b => b.Id == booking.BusId);

            if (bus == null)
            {
                throw new ArgumentException("Invalid Bus");
            }

            // 3. Check seat number
            if (booking.SeatNumber < 1 ||
                booking.SeatNumber > bus.TotalSeats)
            {
                throw new ArgumentException(
                    $"Seat number must be between 1 to {bus.TotalSeats}"
                );
            }

            // 4. Check whether destination state exists
            var state = context.States
                .FirstOrDefault(s => s.Id == booking.StateId);

            if (state == null)
            {
                throw new ArgumentException(
                    "Invalid destination state"
                );
            }

            // 5. Check whether the same seat is already booked
            var seatAlreadyBooked = context.Bookings.Any(b =>
                b.BusId == booking.BusId &&
                b.TravelDate.Date == booking.TravelDate.Date &&
                b.SeatNumber == booking.SeatNumber
            );

            if (seatAlreadyBooked)
            {
                throw new ArgumentException(
                    "This seat is already booked for the selected date"
                );
            }

            // 6. Create passenger
            var passenger = new Passenger();

            context.Passengers.Add(passenger);

            // 7. Create booking
            var booking1 = new Booking
            {
                BusId = booking.BusId,
                StateId = booking.StateId,
                TravelDate = booking.TravelDate,
                SeatNumber = booking.SeatNumber,
                Passenger = passenger
            };

            context.Bookings.Add(booking1);

            // 8. Save changes
            context.SaveChanges();

            // 9. Return booking
            return booking1;
        }
    }
}