using Application.Services;
using Domain.Entities;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repository;

namespace Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IGenericRepositoryAsync<Event>, GenericRepositoryBaseAsync<Event, ApplicationDbContext>>();

            services.AddScoped<ISeatedEventService, SeatedEventService>();
            services.AddScoped<IGenericRepositoryAsync<SeatedEvent>, GenericRepositoryBaseAsync<SeatedEvent, ApplicationDbContext>>();

            services.AddScoped<IStandingEventService, StandingEventService>();
            services.AddScoped<IGenericRepositoryAsync<StandingEvent>, GenericRepositoryBaseAsync<StandingEvent, ApplicationDbContext>>();

            services.AddScoped<IEventImageService, EventImageService>();
            services.AddScoped<IGenericRepositoryAsync<EventImage>, GenericRepositoryBaseAsync<EventImage, ApplicationDbContext>>();
        }
    }
}
