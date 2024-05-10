using AutoMapper;
using Bogus.Extensions.UnitedKingdom;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Models;
using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapperService _mapperService;

        public ProductService(IProductRepository productRepository, IMapperService mapperService)
        {
            _productRepository = productRepository;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<GetProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var mappedProducts = products.Select(p => new GetProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                Price = p.Price,
                Stock = p.Stock
            });
            return mappedProducts;
        }
        public async Task<bool> EditProduct(int id, EditProductDto editProduct)
        {
            var result = await _productRepository.EditProduct(id, editProduct);
            return result;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProduct(id);
            return result;
        }

        public async Task<string> CreateProduct(CreateProductDto createProductDto)
        {

            var mappedProducts = _mapperService.CreateProductDtoToProduct(createProductDto);
            if(_productRepository.VerifyProductByName(mappedProducts.Name).Result && _productRepository.VerifyProductByType(mappedProducts.Type).Result)
            {
                throw new Exception("El producto ya se encuentra registrado");
            }
            
            await _productRepository.CreateProduct(mappedProducts);
            return "Product created successfully";
        }
    }
}