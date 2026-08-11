using _10Aug2026.Models;

namespace _10Aug2026.Repository
{
    public interface IBokkingService
    {
        Booking CreateBookking(Booking booking);

        List<Booking> GetBookings();

        Booking? GetBookingById(int id);
    }
}
