using Taller1.Src.Models;
using Taller1.Src.DTOs.ProductDTOs;

namespace Taller1.Src.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<bool> EditProduct(int id, EditProductDto editProduct);
        Task<bool> DeleteProduct(int id);
        Task CreateProduct(Product product);
        Task<bool> VerifyProductByName(string Name);
        Task<bool> VerifyProductByType(string Type);
    }
}