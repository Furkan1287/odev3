using Domain.Entities;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventImage> EventImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VenueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SeatedEventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StandingEventEntityTypeConfiguration());
        }
    }
}
