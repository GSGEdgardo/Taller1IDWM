using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.DTOs.ProductDTOs;

namespace Taller1.Src.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<GetProductDto>> GetProducts();
        public Task<bool> EditProduct(int id, EditProductDto editProduct);

        public Task<bool> DeleteProduct(int id);

        public Task<string> CreateProduct(CreateProductDto createProduct);
    }
}