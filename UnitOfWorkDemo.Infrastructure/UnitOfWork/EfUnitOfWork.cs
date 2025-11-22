using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Infrastructure.Data;
using UnitOfWorkAndxUnit.Infrastructure.Repositories;

namespace UnitOfWorkAndxUnit.Infrastructure.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository? _productRepository;
        private OrderRepository? _orderRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
