using Microsoft.AspNetCore.Http;

namespace Domain.DTOs
{
    public class EventImageUploadDto
    {
        public Guid EventId { get; set; }
        public IEnumerable<IFormFile>? Images { get; set; }
    }

    public class EventImageDetailDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
