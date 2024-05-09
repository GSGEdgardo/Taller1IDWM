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
        public async Task<bool> EditProduct(int id, EditProductDto editProduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
            if(editProduct.Name!=null){
                existingProduct.Name = editProduct.Name;

            }
            if(editProduct.Price.HasValue){
                existingProduct.Price = editProduct.Price.Value;

            }
            if(editProduct.Stock.HasValue){
                existingProduct.Stock = editProduct.Stock.Value;

            }
            if(editProduct.Type!=null){
                existingProduct.Type = editProduct.Type;

            }
            if(editProduct.Image!=null){
                existingProduct.Image = editProduct.Image;
            }

            _context.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyProductByName(string Name)
        {
            var product = await _context.Products.Where(p => p.Name == Name)
                                                    .FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> VerifyProductByType(string Type)
        {
            var product = await _context.Products.Where(p => p.Type == Type)
                                                    .FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }
            return true;
        }
    }
}