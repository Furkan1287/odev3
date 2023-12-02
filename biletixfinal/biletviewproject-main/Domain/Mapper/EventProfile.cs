using AutoMapper;

namespace Domain.Mapper
{
    public class EventDetailDto: Profile
    {
        public EventDetailDto()
        {
            CreateMap<Entities.Event, DTOs.EventDetailDto>().ReverseMap();
        }
    }
    public class StandingEventProfile : Profile
    {
        public StandingEventProfile()
        {
            CreateMap<Entities.StandingEvent, DTOs.StandingEventCreateDto>().ReverseMap();
            CreateMap<Entities.StandingEvent, DTOs.StandingEventDetailDto>().ReverseMap();
        }
    }

    public class SeatedEventProfile : Profile
    {
        public SeatedEventProfile()
        {
            CreateMap<Entities.SeatedEvent, DTOs.SeatedEventCreateDto>().ReverseMap();
            CreateMap<Entities.SeatedEvent, DTOs.SeatedEventDetailDto>().ReverseMap();
        }
    }
}
