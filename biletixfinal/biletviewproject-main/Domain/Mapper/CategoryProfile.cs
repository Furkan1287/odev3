using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDetailDto>().ReverseMap();
        }
    }
}
