using AutoMapper;

namespace Domain.Mapper
{
    public class EventImageProfile : Profile
    {
        public EventImageProfile() 
        {
            CreateMap<Entities.EventImage, DTOs.EventImageUploadDto>().ReverseMap();
            CreateMap<Entities.EventImage, DTOs.EventImageDetailDto>().ReverseMap();
        }
    }
}
