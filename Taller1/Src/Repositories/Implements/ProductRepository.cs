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
        public async Task<bool> EditProduct (int id, EditProductDto editProduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if(existingProduct == null)
            {
                return false;
            }
            existingProduct.Name = editProduct.Name;
            existingProduct.Price = editProduct.Price;
            existingProduct.Stock = editProduct.Stock;
            existingProduct.Type = editProduct.Type;
            existingProduct.Image = editProduct.Image;

            _context.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}