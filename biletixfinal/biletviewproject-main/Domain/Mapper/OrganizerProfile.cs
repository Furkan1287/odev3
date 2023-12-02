using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {
            CreateMap<Organizer, OrganizerDetailDto>().ReverseMap();
        }
    }
}
