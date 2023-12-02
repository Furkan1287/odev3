using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class EventImageEntityTypeConfiguration
        :  IEntityTypeConfiguration<EventImage>
    {
        public void Configure(EntityTypeBuilder<EventImage> builder)
        {
            builder.ToTable("EventImages");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ImageUrl)
                .HasMaxLength(int.MaxValue);
        }
    }
}
