using Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketCount { get; set; }
        public bool IsFree { get; set; }
        public IEnumerable<EventImage>? Images { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OrganizerId { get; set; }
        public Guid VenueId { get; set; }
        public Category? Category { get; set; }
        public Organizer? Organizer { get; set; }
        public Venue? Venue { get; set; }
    }

    public class SeatedEvent : Event
    {
        [Column(TypeName = "jsonb")]
        public IEnumerable<Seat>? Seats { get; set; }
        public bool IsSeatedEvent { get => true; }
    }

    public class StandingEvent : Event
    {
        public decimal? Price { get; set; }
        public bool IsSeatedEvent { get => false; }
    }

}
