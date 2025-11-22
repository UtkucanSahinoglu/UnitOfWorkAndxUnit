using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Application.Services;

namespace UnitOfWorkAndxUnit.Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnProductsFromRepository()
        {
            var sample = new List<Product>
            {
                new Product { Id = 1, Name = "A", Price = 10 },
                new Product { Id = 2, Name = "B", Price = 20 }
            };

            var productRepoMock = new Mock<IProductRepository>();
            productRepoMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(sample);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(u => u.Products).Returns(productRepoMock.Object);

            IProductService service = new ProductService(uowMock.Object);

            var result = await service.GetAllProductsAsync();

            Assert.Equal(2, System.Linq.Enumerable.Count(result));
            productRepoMock.Verify(r => r.GetAllAsync(), Times.Once);
            uowMock.VerifyGet(u => u.Products, Times.AtLeastOnce);
            uowMock.Verify(u => u.CommitAsync(), Times.Never);
        }

        [Fact]
        public async Task AddProductAsync_ShouldCallRepoAdd_And_UowCommit()
        {
            var newProduct = new Product { Name = "Keyboard", Price = 1500 };

            var productRepoMock = new Mock<IProductRepository>();
            productRepoMock
                .Setup(r => r.AddAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(u => u.Products).Returns(productRepoMock.Object);
            uowMock.Setup(u => u.CommitAsync()).ReturnsAsync(1);

            IProductService service = new ProductService(uowMock.Object);

            await service.AddProductAsync(newProduct);

            productRepoMock.Verify(r => r.AddAsync(It.Is<Product>(p => p.Name == "Keyboard" && p.Price == 1500)), Times.Once);
            uowMock.Verify(u => u.CommitAsync(), Times.Once);
        }
    }
}
