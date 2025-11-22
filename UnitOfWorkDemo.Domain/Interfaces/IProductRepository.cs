using UnitOfWorkAndxUnit.Domain.Entities;

namespace UnitOfWorkAndxUnit.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetExpensiveProductsAsync(decimal minPrice);
    }
}
