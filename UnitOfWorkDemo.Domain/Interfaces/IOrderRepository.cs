using UnitOfWorkAndxUnit.Domain.Entities;

namespace UnitOfWorkAndxUnit.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrderWithProductsAsync(int orderId);
        Task<IEnumerable<Order>> GetRecentOrdersAsync(int days);
    }
}
