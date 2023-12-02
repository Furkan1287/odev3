using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class VenueProfile : Profile
    {
        public VenueProfile()
        {
            CreateMap<Venue, VenueDetailDto>().ReverseMap();
        }
    }
}
