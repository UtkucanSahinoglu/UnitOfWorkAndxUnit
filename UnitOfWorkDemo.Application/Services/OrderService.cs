using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Domain.Interfaces;

namespace UnitOfWorkAndxUnit.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order?> GetOrderWithProductsAsync(int id)
        {
            return await _unitOfWork.Orders.GetOrderWithProductsAsync(id);
        }

        public async Task AddOrderAsync(Order order, List<int> productIds)
        {
            if (productIds == null || !productIds.Any())
                throw new ArgumentException("Siparişe en az bir ürün eklenmelidir.");

            var products = new List<OrderProduct>();
            foreach (var pid in productIds)
            {
                products.Add(new OrderProduct { ProductId = pid, Quantity = 1 });
            }

            order.OrderDate = DateTime.Now;
            order.OrderProducts = products;

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CommitAsync();
        }
    }
}
