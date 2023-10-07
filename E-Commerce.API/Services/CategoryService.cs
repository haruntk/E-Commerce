using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace E_Commerce.API.Services
{
    public class CategoryService : ICategoryService
    {
        const string cacheKey = "categoriesKey";
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
        }
        public async Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            if (!memoryCache.TryGetValue(cacheKey, out List<CategoryDto> categoriesByCache))
            {
                var categories = await categoryRepository.GetAllAsync();
                var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
                if (categoriesDto == null)
                {
                    return new ApiResponseDto<List<CategoryDto>>
                    {
                        Data = categoriesDto,
                        IsSuccess = false,
                        Message = "There is no category"
                    };
                }
                memoryCache.Set(cacheKey, categoriesDto, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal
                });
                return new ApiResponseDto<List<CategoryDto>>
                {
                    Data = categoriesDto,
                    IsSuccess = true,
                    Message = "Transaction Completed Successfully"
                };
            }
            return new ApiResponseDto<List<CategoryDto>>
            {
                Data = categoriesByCache,
                IsSuccess = true,
                Message = "Transaction Completed Successfully with In-Memory Cache"
            };
        }
        public async Task<ApiResponseDto<CategoryDto>> AddAsync(AddCategoryRequestDto addCategoryRequestDto)
        {
            memoryCache.Remove(cacheKey);
            var category = mapper.Map<Category>(addCategoryRequestDto);
            category.Id = Guid.NewGuid();
            await categoryRepository.CreateAsync(category);
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
        public async Task<ApiResponseDto<CategoryDto?>> DeleteAsync(Guid id)
        {
            memoryCache.Remove(cacheKey);
            var deletedCategory = await categoryRepository.GetByIdAsync(id);
            var deletedCategoryDto = mapper.Map<CategoryDto>(deletedCategory);

            if (deletedCategory == null)
            {
                return new ApiResponseDto<CategoryDto?>
                {
                    IsSuccess = false,
                    Message = "Category Not Found"
                };
            }
            categoryRepository.DeleteAsync(deletedCategory);
            return new ApiResponseDto<CategoryDto?>
            {
                Data = deletedCategoryDto,
                IsSuccess = true,
                Message = "Category Deleted Successfully"
            };
        }
    }
}
