using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;

namespace E_Commerce.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);

            if (categoriesDto == null)
            {
                return new ApiResponseDto<List<CategoryDto>>
                {
                    IsSuccess = false,
                    Message = "Operation Failed"
                };
            }
            return new ApiResponseDto<List<CategoryDto>>
            {
                Data = categoriesDto,
                IsSuccess = true,
                Message = "Transaction Completed Successfully"
            };
        }
        public async Task<ApiResponseDto<CategoryDto>> AddAsync(AddCategoryRequestDto addCategoryRequestDto)
        {
            var category = await categoryRepository.CreateAsync(addCategoryRequestDto);
            var categoryDto = mapper.Map<CategoryDto>(category);
            if (categoryDto == null)
            {
                return new ApiResponseDto<CategoryDto>
                {
                    IsSuccess = false,
                    Message = "Category could not be added"
                };
            }
            return new ApiResponseDto<CategoryDto>
            {
                Data = categoryDto,
                IsSuccess = true,
                Message = "Transaction Completed Successfully"
            };
        }
        public async Task<ApiResponseDto<CategoryDto>> DeleteAsync(Guid id)
        {
            var deletedCategory = await categoryRepository.DeleteAsync(id);
            var deletedCategoryDto = mapper.Map<CategoryDto>(deletedCategory);

            if (deletedCategoryDto == null)
            {
                return new ApiResponseDto<CategoryDto>
                {
                    IsSuccess = false,
                    Message = "Category Not Found"
                };
            }
            return new ApiResponseDto<CategoryDto>
            {
                Data = deletedCategoryDto,
                IsSuccess = true,
                Message = "Category Deleted Successfully"
            };
        }
    }
}
