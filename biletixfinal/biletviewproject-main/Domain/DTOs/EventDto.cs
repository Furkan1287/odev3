using Domain.Entities;

namespace Domain.DTOs
{
    #region Event
    public class EventCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketCount { get; set; }
        public bool IsFree { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OrganizerId { get; set; }
        public Guid VenueId { get; set; }
    }

    public class EventDetailDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketCount { get; set; }
        public bool IsFree { get; set; }
        public bool IsSeatedEvent { get; set; }
        public CategoryDetailDto Category { get; set; }
        public OrganizerDetailDto Organizer { get; set; }
        public VenueDetailDto Venue { get; set; }
        public List<EventImageDetailDto> Images { get; set; }
        
    }
    #endregion

    #region SeatedEvent
    public class SeatedEventCreateDto : EventCreateDto
    {
        public decimal? VIPSeatPrice { get; set; }
        public int VIPSeatCount { get; set; }
        public decimal? PremiumSeatPrice { get; set; }
        public int PremiumSeatCount { get; set; }
        public decimal? StandartSeatPrice { get; set; }
        public int StandartSeatCount { get; set; }
        public decimal? StudentSeatPrice { get; set; }
        public int StudentSeatCount { get; set; }
        public decimal? DisabledSeatPrice { get; set; }
        public int DisabledSeatCount { get; set; }
    }

    public class SeatedEventDetailDto : EventDetailDto
    {
        public IEnumerable<Seat>? Seats { get; set; }
        public bool IsSeatedEvent { get => true; }
    }

    #endregion

    #region StandingEvent
    public class StandingEventCreateDto : EventCreateDto
    {
        public decimal? Price { get; set; }
    }

    public class StandingEventDetailDto : EventDetailDto 
    {
        public decimal? Price { get; set; }
        public bool IsSeatedEvent { get => false; }
    }
    #endregion
}
