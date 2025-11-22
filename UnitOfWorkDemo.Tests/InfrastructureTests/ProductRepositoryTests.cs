using Microsoft.EntityFrameworkCore;
using System;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Infrastructure.Data;
using UnitOfWorkAndxUnit.Infrastructure.Repositories;

public class ProductRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldAddProduct()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new AppDbContext(options);
        var repo = new ProductRepository(context);

        var product = new Product { Name = "Test", Price = 100 };
        await repo.AddAsync(product);
        await context.SaveChangesAsync();

        Assert.Single(await repo.GetAllAsync());
    }
}
