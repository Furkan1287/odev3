namespace Domain.DTOs
{
    public class VenueDetailDto
    {
        public Guid Id { get; set; }
        public string VenueName { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string GoogleMapsSrc { get; set; }
    }
}
