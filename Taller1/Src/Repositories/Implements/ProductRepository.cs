using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.Models;
using Taller1.Src.Data;
using Microsoft.EntityFrameworkCore;
using Taller1.Src.DTOs.ProductDTOs;

namespace Taller1.Src.Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

    }
}