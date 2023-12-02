using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class EventEntityTypeConfiguration
        : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Events);

            builder.HasOne(e => e.Organizer)
                .WithMany(e => e.Events);

            builder.HasOne(e => e.Venue)
                .WithMany(e => e.Events);

            builder.HasMany(e => e.Images)
                .WithOne(e => e.Event);
        }
    }

    public class SeatedEventEntityTypeConfiguration
        : IEntityTypeConfiguration<SeatedEvent>
    {
        public void Configure(EntityTypeBuilder<SeatedEvent> builder)
        {
            builder.ToTable("SeatedEvents")
                .HasBaseType<Event>();
        }
    }

    public class StandingEventEntityTypeConfiguration
        : IEntityTypeConfiguration<StandingEvent>
    {
        public void Configure(EntityTypeBuilder<StandingEvent> builder)
        {
            builder.ToTable("StandingEvents")
                .HasBaseType<Event>();

        }
    }
}
