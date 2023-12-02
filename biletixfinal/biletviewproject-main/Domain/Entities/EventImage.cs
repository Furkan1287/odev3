using Shared.Entities;

namespace Domain.Entities
{
    public class EventImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }

    }
}
