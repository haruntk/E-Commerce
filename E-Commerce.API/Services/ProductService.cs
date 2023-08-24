using AutoMapper;
using AutoMapper.Internal;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;

namespace E_Commerce.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ApiResponseDto<ProductDto>> AddAsync(AddProductRequestDto addProductRequestDto)
        {
            var productDto = await productRepository.CreateAsyncToDatabase(addProductRequestDto);
            var apiResponse = new ApiResponseDto<ProductDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Something Went Wrong";
            if (productDto != null)
            {
                apiResponse.Data = productDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Transaction Completed Successfully";
                return apiResponse;
            }
            return apiResponse;
        }

        public async Task<ApiResponseDto<ProductDto>> DeleteAsync(Guid id)
        {
            var deletedProduct = await productRepository.DeleteAsyncFromDatabase(id);

            var deletedProductDto = mapper.Map<ProductDto>(deletedProduct);

            var apiResponse = new ApiResponseDto<ProductDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Product Not Found!";
            if (deletedProductDto != null)
            {
                apiResponse.Data = deletedProductDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Product Deleted Successfully";
                return apiResponse;
            }
            return apiResponse;
        }

        public async Task<ApiResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await productRepository.GetAllFromDatabase();
            var productsDto = mapper.Map<List<ProductDto>>(products);
            var apiResponse = new ApiResponseDto<List<ProductDto>>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Something Went Wrong";

            if (productsDto != null)
            {
                apiResponse.Data = productsDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Transaction Completed Successfully";
                return apiResponse;
            }

            return apiResponse;
        }

        public async Task<ApiResponseDto<ProductDto>> GetByIdAsync(Guid id)
        {
            var productDto = await productRepository.GetByIdFromDatabase(id);
            var apiResponse = new ApiResponseDto<ProductDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Product Not Found";
            if (productDto != null)
            {
                apiResponse.Data = productDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Product Found Successfully";
                return apiResponse;
            }
            return apiResponse;
        }

        public async Task<ApiResponseDto<ProductDto>> UpdateAsync(Guid id, UpdateProductRequestDto updateProductRequestDto)
        {
            var productDto = await productRepository.UpdateByIdToDatabase(id, updateProductRequestDto);
            var apiResponse = new ApiResponseDto<ProductDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Product Not Found";
            if (productDto != null)
            {
                apiResponse.Data = productDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Product Updated Successfully";
                return apiResponse;
            }
            return apiResponse;
        }
    }
}
