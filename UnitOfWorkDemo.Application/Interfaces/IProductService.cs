using UnitOfWorkAndxUnit.Domain.Entities;

namespace UnitOfWorkAndxUnit.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetExpensiveProductsAsync(decimal minPrice);
    }
}
