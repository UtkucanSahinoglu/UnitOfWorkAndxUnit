using UnitOfWorkAndxUnit.Domain.Entities;

namespace UnitOfWorkAndxUnit.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderWithProductsAsync(int id);
        Task AddOrderAsync(Order order, List<int> productIds);
    }
}
