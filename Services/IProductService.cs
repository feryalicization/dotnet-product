using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();  // Get all products asynchronously
        Task<Product?> GetByIdAsync(int id);       // Get a product by id asynchronously
        Task<Product> AddAsync(Product product);   // Add a new product asynchronously
        Task<Product> UpdateAsync(Product product); // Update product asynchronously
        Task<bool> DeleteAsync(int id);             // Delete product by id asynchronously
    }
}
