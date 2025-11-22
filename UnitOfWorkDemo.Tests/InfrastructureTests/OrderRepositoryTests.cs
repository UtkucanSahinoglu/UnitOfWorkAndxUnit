using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAndxUnit.Application.Services;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Infrastructure.Data;
using UnitOfWorkAndxUnit.Infrastructure.UnitOfWork;

namespace UnitOfWorkAndxUnit.Tests.InfrastructureTests
{
    public class OrderRepositoryTests
    {
        [Fact]
        public async Task AddOrder_ShouldPersistToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderDbTest")
                .Options;

            // Yeni context oluştur (InMemory DB)
            using var context = new AppDbContext(options);
            var uow = new EfUnitOfWork(context);
            var service = new OrderService(uow);

            // Ürünleri ekle (önce Product'ları ekliyoruz çünkü Order onlara bağlanacak)
            context.Products.AddRange(
                new Product { Name = "Mouse", Price = 300 },
                new Product { Name = "Keyboard", Price = 700 }
            );
            await context.SaveChangesAsync();

            // Order nesnesi
            var order = new Order
            {
                CustomerName = "Ali Veli",
                TotalAmount = 1000 // test amaçlı, gerçek hesaplama servis içinde de yapılabilir
            };

            var productIds = context.Products.Select(p => p.Id).ToList();

            // Act
            await service.AddOrderAsync(order, productIds);

            // Assert
            var orders = await uow.Orders.GetAllAsync();
            Assert.Single(orders); // sadece 1 order olmalı

            var addedOrder = orders.First();
            Assert.Equal("Ali Veli", addedOrder.CustomerName);

            // ilişkili kayıtlar da eklenmiş olmalı
            var orderInDb = await context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync();

            Assert.NotNull(orderInDb);
            Assert.Equal(2, orderInDb!.OrderProducts.Count); // 2 ürün eklendi
        }
    }
}
