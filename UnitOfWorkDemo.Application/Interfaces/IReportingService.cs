namespace UnitOfWorkAndxUnit.Application.Interfaces
{
    public interface IReportingService
    {
        Task<decimal> GetTotalSalesAsync();
        Task<int> GetTotalOrdersAsync();
        Task<decimal> GetAverageOrderValueAsync();
        Task<IEnumerable<object>> GetTopSellingProductsAsync(int top = 5);
    }
}
