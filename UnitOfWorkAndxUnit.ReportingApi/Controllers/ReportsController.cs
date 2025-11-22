using Microsoft.AspNetCore.Mvc;
using UnitOfWorkAndxUnit.Application.Interfaces;

namespace UnitOfWorkAndxUnit.ReportingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet("totalsales")]
        public async Task<IActionResult> GetTotalSales()
        {
            var total = await _reportingService.GetTotalSalesAsync();
            return Ok(new { TotalSales = total });
        }

        [HttpGet("totalorders")]
        public async Task<IActionResult> GetTotalOrders()
        {
            var total = await _reportingService.GetTotalOrdersAsync();
            return Ok(new { TotalOrders = total });
        }

        [HttpGet("averageorder")]
        public async Task<IActionResult> GetAverageOrderValue()
        {
            var avg = await _reportingService.GetAverageOrderValueAsync();
            return Ok(new { AverageOrderValue = avg });
        }

        [HttpGet("topselling/{count?}")]
        public async Task<IActionResult> GetTopSellingProducts(int count = 5)
        {
            var result = await _reportingService.GetTopSellingProductsAsync(count);
            return Ok(result);
        }
    }
}
