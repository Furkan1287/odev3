using System;

namespace Domain.DTOs
{
    public class CategoryDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}