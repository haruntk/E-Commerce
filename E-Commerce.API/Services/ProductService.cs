using AutoMapper;
using AutoMapper.Internal;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;
using E_Commerce.API.Validations;

namespace E_Commerce.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<ApiResponseDto<Guid>> AddAsync(AddProductRequestDto addProductRequestDto)
        {
            var validator = new ProductCategoryValidator();
            var result = await validator.ValidateAsync(addProductRequestDto);
            if (result.IsValid)
            {
                var product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = addProductRequestDto.Name,
                    Price = addProductRequestDto.Price,
                    Quantity = addProductRequestDto.Quantity,
                };
                foreach (var item in addProductRequestDto.ProductCategories)
                {
                    if (item.IsMain)
                    {
                        product.MainCategoryId = item.CategoryId;
                    }
                }
                productRepository.CreateAsync(product);
                var productCateogoryEntities = GetProductCategoryEntities(product.Id, addProductRequestDto.ProductCategories);
                var affectedRowCount = await productCategoryRepository.Create(productCateogoryEntities);
                if (affectedRowCount == 0)
                {
                    return new ApiResponseDto<Guid>()
                    {
                        IsSuccess = false,
                        Message = "The product could not be added."
                    };
                }
                return new ApiResponseDto<Guid>()
                {
                    Data = product.Id,
                    IsSuccess = true,
                    Message = "Transaction Completed Successfully"
                };
            }
            return new ApiResponseDto<Guid>
            {
                IsSuccess = false,
                Message = "The entered informations are not correct."
            };
        }

        private List<ProductCategory> GetProductCategoryEntities(Guid productId, List<AddProductCategoryDto> dto)
        {
            var productCategories = new List<ProductCategory>();
            foreach (var productCategoryDto in dto)
            {
                productCategories.Add(new ProductCategory
                {
                    Id = Guid.NewGuid(),
                    CategoryId = productCategoryDto.CategoryId,
                    ProductId = productId,
                    IsMain = productCategoryDto.IsMain
                });
            }
            return productCategories;
        }
        public async Task<ApiResponseDto<ProductDto>> DeleteAsync(Guid id)
        {
            var deletedProduct = await productRepository.DeleteAsync(id);

            var deletedProductDto = mapper.Map<ProductDto>(deletedProduct);
            if (deletedProductDto == null)
            {
                return new ApiResponseDto<ProductDto>()
                {
                    IsSuccess = false,
                    Message = "Operation Failed"
                };
            }
            return new ApiResponseDto<ProductDto>
            {
                Data = deletedProductDto,
                IsSuccess = true,
                Message = "Product Deleted Successfully"
            };
        }

        public async Task<ApiResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            var productsDto = mapper.Map<List<ProductDto>>(products);
            if (productsDto == null)
            {
                return new ApiResponseDto<List<ProductDto>>
                {
                    Data = productsDto,
                    IsSuccess = false,
                    Message = "No products were found in the database"
                };
            }
            return new ApiResponseDto<List<ProductDto>>
            {
                Data = productsDto,
                IsSuccess = true,
                Message = "Transaction Completed Successfully"
            };
        }

        public async Task<ApiResponseDto<ProductDto>> GetByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            var productDto = mapper.Map<ProductDto>(product);
            if (productDto == null)
            {
                return new ApiResponseDto<ProductDto>
                {
                    IsSuccess = false,
                    Message = "Product Not Found"
                };
            }
            return new ApiResponseDto<ProductDto>
            {
                Data = productDto,
                IsSuccess = true,
                Message = "Product Found Successfully"
            };
        }

        public async Task<ApiResponseDto<ProductDto>> UpdateAsync(Guid id, UpdateProductRequestDto updateProductRequestDto)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return new ApiResponseDto<ProductDto>
                {
                    IsSuccess = false,
                    Message = "Product Not Found"
                };
            }
            product.Quantity = updateProductRequestDto.Quantity;
            product.Price = updateProductRequestDto.Price;
            product.MainCategoryId = updateProductRequestDto.MainCategoryId;
            product.Name = updateProductRequestDto.Name;

            productRepository.UpdateByIdAsync(product);
            var productDto = mapper.Map<ProductDto>(product);
            return new ApiResponseDto<ProductDto>
            {
                Data = productDto,
                IsSuccess = true,
                Message = "Product Updated Successfully"
            };
        }
    }
}
