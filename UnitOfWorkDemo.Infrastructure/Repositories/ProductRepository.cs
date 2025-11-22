using Microsoft.EntityFrameworkCore;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Infrastructure.Data;

namespace UnitOfWorkAndxUnit.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetExpensiveProductsAsync(decimal minPrice)
        {
            return await _dbSet.Where(p => p.Price > minPrice).AsNoTracking().ToListAsync();
        }
    }
}
