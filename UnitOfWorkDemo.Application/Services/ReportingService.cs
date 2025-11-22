using Microsoft.EntityFrameworkCore;
using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Infrastructure.Data;

namespace UnitOfWorkAndxUnit.Application.Services
{
    public class ReportingService : IReportingService
    {
        private readonly AppDbContext _context;

        public ReportingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalSalesAsync()
        {
            return await _context.Orders.SumAsync(o => o.TotalAmount);
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetAverageOrderValueAsync()
        {
            if (!await _context.Orders.AnyAsync()) return 0;
            return await _context.Orders.AverageAsync(o => o.TotalAmount);
        }

        public async Task<IEnumerable<object>> GetTopSellingProductsAsync(int top = 5)
        {
            return await _context.OrderProducts
                .Include(op => op.Product)
                .GroupBy(op => op.Product.Name)
                .Select(g => new
                {
                    Product = g.Key,
                    Quantity = g.Sum(x => x.Quantity),
                    Revenue = g.Sum(x => x.Quantity * x.Product.Price)
                })
                .OrderByDescending(x => x.Quantity)
                .Take(top)
                .ToListAsync();
        }
    }
}
