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
            var categories = await categoryRepository.GetAllAsyncFromDatabase();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            var apiResponse = new ApiResponseDto<List<CategoryDto>>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Something Went Wrong";

            if (categoriesDto != null)
            {
                apiResponse.Data = categoriesDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Transaction Completed Successfully";
                return apiResponse;
            }

            return apiResponse;
        }
        public async Task<ApiResponseDto<CategoryDto>> AddAsync(AddCategoryRequestDto addCategoryRequestDto)
        {
            var categoryDto = await categoryRepository.CreateAsyncToDatabase(addCategoryRequestDto);

            var apiResponse = new ApiResponseDto<CategoryDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Something Went Wrong";
            if (categoryDto != null)
            {
                apiResponse.Data = categoryDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Transaction Completed Successfully";
                return apiResponse;
            }
            return apiResponse;
        }
        public async Task<ApiResponseDto<CategoryDto>> DeleteAsync(Guid id)
        {
            var deletedCategory = await categoryRepository.DeleteAsyncFromDatabase(id);

            var deletedCategoryDto = mapper.Map<CategoryDto>(deletedCategory);

            var apiResponse = new ApiResponseDto<CategoryDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Category Not Found!";
            if (deletedCategoryDto != null)
            {
                apiResponse.Data = deletedCategoryDto;
                apiResponse.IsSuccess =true;
                apiResponse.Message = "Category Deleted Successfully";
                return apiResponse;
            }
            return apiResponse;

        }
    }
}
