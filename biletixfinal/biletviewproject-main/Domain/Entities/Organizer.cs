using Shared.Entities;

namespace Domain.Entities
{
    public class Organizer : BaseEntity
    {
        public string OrganizerName { get; set; }
        public IEnumerable<Event>? Events { get; set; }
    }
}
