using System.ComponentModel.DataAnnotations;

namespace _10Aug2026.Models
{
    public class Booking
    {
       public int Id { get; set; }

        public int PassengerId {  get; set; }

        public int BusId {  get; set; }

        public int StateId {  get; set; }

        [Required(ErrorMessage ="Date is required")]
        public DateTime TravelDate{  get; set; }

        [Required(ErrorMessage = "SeatNumber is required")]
        [Range(1,50)]
        public int SeatNumber {  get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1000,100000)]
        public decimal Fare {  get; set; }

        public Passenger? Passenger {  get; set; }

        public Bus? Bus { get; set; }

        public State? State { get; set; }
    }
}
