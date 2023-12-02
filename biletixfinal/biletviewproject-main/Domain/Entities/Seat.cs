namespace Domain.Entities
{
    public class Seat
    {
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public decimal? SeatPrice { get; set; }
    }
    public enum SeatType
    {
        VIP = 1,
        Premium = 2,
        Standart = 3,
        Student = 4,
        Disabled = 5,
    }

}
