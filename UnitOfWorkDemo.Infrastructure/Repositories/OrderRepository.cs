using Microsoft.EntityFrameworkCore;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Infrastructure.Data;

namespace UnitOfWorkAndxUnit.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<Order?> GetOrderWithProductsAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetRecentOrdersAsync(int days)
        {
            var limit = DateTime.UtcNow.AddDays(-days);
            return await _dbSet
                .Where(o => o.OrderDate >= limit)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
