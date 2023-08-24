using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, ApiResponseDto<CategoryDto>>().ReverseMap();
            CreateMap<Category, AddCategoryRequestDto>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<AddProductRequestDto, Product>().ReverseMap();
            CreateMap<UpdateProductRequestDto,ProductDto>().ReverseMap();
            CreateMap<IdentityUser,UserDto>().ReverseMap();
        }
    }
}
