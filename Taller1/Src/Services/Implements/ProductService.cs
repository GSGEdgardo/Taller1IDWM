using Bogus.Extensions.UnitedKingdom;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<IEnumerable<GetProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var mappedProducts = products.Select(p => new GetProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Type = p.Type,
                Price = p.Price,
                Stock = p.Stock
            });
            return mappedProducts;
        }


    }

}