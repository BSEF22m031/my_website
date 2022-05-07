using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_lab_06.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int GuestCount { get; set; }
    }
}
