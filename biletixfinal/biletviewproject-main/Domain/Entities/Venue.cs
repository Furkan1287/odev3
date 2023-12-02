using Shared.Entities;

namespace Domain.Entities
{
    public class Venue : BaseEntity
    {
        public string VenueName { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string GoogleMapsSrc { get; set; }
        public IEnumerable<Event>? Events { get; set; }
    }
}
