using ProductApi.Models;
using ProductApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => p.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.DeletedAt == null)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Product> AddAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var existing = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id && p.DeletedAt == null);
            if (existing == null) throw new Exception("Product not found");

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);
            if (product == null) return false;

            product.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
