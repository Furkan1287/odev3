namespace Shared.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
