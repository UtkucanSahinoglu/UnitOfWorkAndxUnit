using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Application.Services;
using UnitOfWorkAndxUnit.Application.Interfaces;

namespace UnitOfWorkAndxUnit.Tests.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task AddOrderAsync_ShouldCreateOrderWithProducts_AndCommit()
        {
            var order = new Order
            {
                CustomerName = "Test Customer",
                TotalAmount = 3000
            };

            var productIds = new List<int> { 1, 2, 3 };

            var mockOrderRepo = new Mock<IOrderRepository>();
            mockOrderRepo
                .Setup(r => r.AddAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(u => u.Orders).Returns(mockOrderRepo.Object);
            mockUow.Setup(u => u.CommitAsync()).ReturnsAsync(1);

            IOrderService service = new OrderService(mockUow.Object);

            await service.AddOrderAsync(order, productIds);

            mockOrderRepo.Verify(r => r.AddAsync(It.Is<Order>(o => o.OrderProducts.Count == productIds.Count)), Times.Once);
            mockUow.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task AddOrderAsync_ShouldThrowException_WhenNoProductsProvided()
        {
            var order = new Order { CustomerName = "Empty Order" };
            var productIds = new List<int>(); 

            var mockOrderRepo = new Mock<IOrderRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(u => u.Orders).Returns(mockOrderRepo.Object);

            IOrderService service = new OrderService(mockUow.Object);

            await Assert.ThrowsAsync<ArgumentException>(() => service.AddOrderAsync(order, productIds));
            mockOrderRepo.Verify(r => r.AddAsync(It.IsAny<Order>()), Times.Never);
            mockUow.Verify(u => u.CommitAsync(), Times.Never);
        }
    }
}
