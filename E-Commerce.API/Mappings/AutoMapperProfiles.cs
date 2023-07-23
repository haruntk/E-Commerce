using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, ApiResponseDto<CategoryDto>>().ReverseMap();
            CreateMap<Category, AddCategoryRequestDto>().ReverseMap();
        }
    }
}
